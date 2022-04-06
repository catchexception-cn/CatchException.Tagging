using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;

using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace CatchException.Tagging.Tagging;

public abstract class TagLookupService<TTag, TTagRepository> : ITagLookupService<TTag>, ITransientDependency
    where TTag : class, ITag
    where TTagRepository : ITagRepository<TTag>
{
    protected bool SkipExternalLookupIfLocalTagExists { get; set; } = true;

    public IExternalTagLookupServiceProvider? ExternalTagLookupServiceProvider { get; set; }
    public ILogger<TagLookupService<TTag, TTagRepository>> Logger { get; set; }

    private readonly TTagRepository _tagRepository;
    private readonly IUnitOfWorkManager _unitOfWorkManager;

    protected TagLookupService(
        TTagRepository tagRepository,
        IUnitOfWorkManager unitOfWorkManager)
    {
        _tagRepository = tagRepository;
        _unitOfWorkManager = unitOfWorkManager;

        Logger = NullLogger<TagLookupService<TTag, TTagRepository>>.Instance;
    }

    public async Task<TTag?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var localTag = await _tagRepository.FindAsync(id, cancellationToken: cancellationToken);

        if (ExternalTagLookupServiceProvider == null)
        {
            return localTag;
        }

        if (SkipExternalLookupIfLocalTagExists && localTag != null)
        {
            return localTag;
        }

        ITagData? externalTag;

        try
        {
            externalTag = await ExternalTagLookupServiceProvider.FindByIdAsync(id, cancellationToken);
            if (externalTag == null)
            {
                if (localTag != null)
                {
                    //TODO: Instead of deleting, should be make it inactive or something like that?
                    await WithNewUowAsync(() => _tagRepository.DeleteAsync(localTag, cancellationToken: cancellationToken));
                }

                return null;
            }
        }
        catch (Exception ex)
        {
            Logger.LogException(ex);
            return localTag;
        }

        if (localTag == null)
        {
            await WithNewUowAsync(() => _tagRepository.InsertAsync(CreateTag(externalTag), cancellationToken: cancellationToken));
            return await _tagRepository.FindAsync(id, cancellationToken: cancellationToken);
        }

        // ReSharper disable once SuspiciousTypeConversion.Global
        if (localTag is IUpdateTagData data && data.Update(externalTag))
        {
            await WithNewUowAsync(() => _tagRepository.UpdateAsync(localTag, cancellationToken: cancellationToken));
        }
        else
        {
            return localTag;
        }

        return await _tagRepository.FindAsync(id, cancellationToken: cancellationToken);
    }

    protected abstract TTag CreateTag(ITagData externalTag);

    private async Task WithNewUowAsync(Func<Task> func)
    {
        using var uow = _unitOfWorkManager.Begin(requiresNew: true);
        await func();
        await uow.CompleteAsync();
    }
}