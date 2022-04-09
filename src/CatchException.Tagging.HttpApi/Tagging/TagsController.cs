using CatchException.Tagging.Tagging.Dtos;

using Microsoft.AspNetCore.Mvc;

using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace CatchException.Tagging.Tagging
{
    [Area(TaggingRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = TaggingRemoteServiceConsts.RemoteServiceName)]
    [Route("api/tagging/tag")]
    public class TagsController : AbpControllerBase, ITagAppService
    {
        private readonly ITagAppService _tagAppService;

        public TagsController(ITagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        [HttpPut]
        public async Task<TagDto> CreateAsync(CreateTagDto input)
        {
            return await _tagAppService.CreateAsync(input);
        }

        [HttpGet]
        public async Task<List<TagDto>> GetListAsync(GetTagListInput input, CancellationToken cancellationToken)
        {
            return await _tagAppService.GetListAsync(input, cancellationToken);
        }
    }
}
