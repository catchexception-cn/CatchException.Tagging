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

    public async Task<List<ITagData>> SearchAsync(string? filter = null, int maxResultCount = int.MaxValue,
        CancellationToken cancellationToken = default)
    {
        var tags = await TagRepository.SearchAsync(filter, maxResultCount, cancellationToken);

        return tags
            .Select(t => new TagData(t.Id, t.Name, t.Description))
            .Cast<ITagData>()
            .ToList();
    }
}