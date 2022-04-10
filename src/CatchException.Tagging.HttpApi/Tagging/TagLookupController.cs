using Microsoft.AspNetCore.Mvc;

using Volo.Abp;

namespace CatchException.Tagging.Tagging;
[Area(TaggingRemoteServiceConsts.ModuleName)]
[RemoteService(Name = TaggingRemoteServiceConsts.RemoteServiceName)]
[Route("api/tagging/tag-lookup")]
public class TagLookupController : TaggingController, ITagLookupAppService
{
    public ITagLookupAppService AppService
        => LazyServiceProvider.LazyGetRequiredService<ITagLookupAppService>();

    [HttpGet("{id}")]
    public Task<TagData?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return AppService.FindByIdAsync(id, cancellationToken);
    }

    [HttpGet("search")]
    public Task<List<TagData>> SearchAsync(string? filter = null, int maxResultCount = int.MaxValue, CancellationToken cancellationToken = default)
    {
        return AppService.SearchAsync(filter, maxResultCount, cancellationToken);
    }
}