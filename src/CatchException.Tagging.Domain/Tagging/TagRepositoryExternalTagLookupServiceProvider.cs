using Volo.Abp.DependencyInjection;

namespace CatchException.Tagging.Tagging;

public class TagRepositoryExternalTagLookupServiceProvider : IExternalTagLookupServiceProvider, ITransientDependency
{
    protected ITagRepository TagRepository { get; }

    public TagRepositoryExternalTagLookupServiceProvider(ITagRepository tagRepository)
    {
        TagRepository = tagRepository;
    }

    public async Task<ITagData?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return
            (await TagRepository.FindAsync(id, false, cancellationToken))
            ?.ToTagData();
    }
}