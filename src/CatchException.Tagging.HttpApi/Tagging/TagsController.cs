using CatchException.Tagging.Tagging.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace CatchException.Tagging.Tagging
{
    [Area(TaggingRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = TaggingRemoteServiceConsts.RemoteServiceName)]
    [Route("api/Tagging/tag")]
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
        public async Task<List<TagDto>> GetAsync(GetTagsInput input)
        {
           return  await _tagAppService.GetAsync(input);
        }
    }
}
