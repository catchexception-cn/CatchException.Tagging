using CatchException.Tagging.Tagging.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchException.Tagging.Tagging
{
    public class TagAppService : TaggingAppService, ITagAppService
    {
        private readonly ITagRepository _tagRepository;

        public TagAppService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<TagDto>> GetAsync(GetTagsInput input)
        {
            var postTags = (await _tagRepository.GetByNameAsync(input.Name)).Take(input.ResultCount).ToList();

            return new List<TagDto>(
              ObjectMapper.Map<List<Tag>, List<TagDto>>(postTags));
        }

        public async Task<TagDto> CreateAsync(CreateTagDto input)
        {
            var newTag = new Tag(GuidGenerator.Create(), input.Name, 0, input.Description);

            newTag = await _tagRepository.InsertAsync(newTag);

            return ObjectMapper.Map<Tag, TagDto>(newTag);
        }
    }
}
