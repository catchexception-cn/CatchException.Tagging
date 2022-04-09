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
        protected ITagRepository TagRepository =>
            LazyServiceProvider.LazyGetRequiredService<ITagRepository>();

        public async Task<List<TagDto>> GetListAsync(GetTagListInput input, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
            {
                return new List<TagDto>();
            }
            var query = (await TagRepository.GetQueryableAsync())
                .Where(t => t.Name.Contains(input.Name.Trim()))
                .OrderByDescending(t => t.UsageCount)
                .Take(input.MaxResultCount);

            return new List<TagDto>(
              ObjectMapper.Map<List<Tag>, List<TagDto>>(
                  await AsyncExecuter.ToListAsync(query, cancellationToken)));
        }

        public async Task<TagDto> CreateAsync(CreateTagDto input)
        {
            var newTag = new Tag(GuidGenerator.Create(), input.Name, 0, input.Description);

            newTag = await TagRepository.InsertAsync(newTag);

            return ObjectMapper.Map<Tag, TagDto>(newTag);
        }
    }
}
