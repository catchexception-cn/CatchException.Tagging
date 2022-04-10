using Volo.Abp.Application.Dtos;

namespace CatchException.Tagging.Tagging;

public abstract class TagLookupBaseAppService<TTag, TTagRepository, TTagLookupService> : TaggingAppService, ITagLookupAppService
    where TTag : class, ITag
    where TTagRepository : ITagRepository<TTag>
    where TTagLookupService : TagLookupService<TTag, TTagRepository>
{
    public TTagLookupService TagLookupService
        => LazyServiceProvider.LazyGetRequiredService<TTagLookupService>();

    public async Task<TagData?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var tagData = await TagLookupService.FindByIdAsync(id, cancellationToken);
        return tagData == null ? null : new TagData(tagData.Id, tagData.Name, tagData.Description);
    }

    public async Task<List<TagData>> SearchAsync(string? filter = null, int maxResultCount = int.MaxValue,
        CancellationToken cancellationToken = default)
    {
        return (await TagLookupService.SearchAsync(filter, maxResultCount, cancellationToken))
            .Cast<TagData>()
            .ToList();
    }
}