using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace CatchException.Tagging.Tagging
{
    public class TagUsageCountChangedEventHandler : IDistributedEventHandler<TagUsageCountChangedEto>, ITransientDependency
    {
        private readonly ITagRepository _tagRepository;

        public TagUsageCountChangedEventHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task HandleEventAsync(TagUsageCountChangedEto eventData)
        {
            var tag = await _tagRepository.FindAsync(eventData.Id);
            if (tag == null)
            {
                return;
            }

            if (eventData.UsageCountEnum == UsageCountEnum.Increase)
            {
                tag.IncreaseUsageCount();
            }
            else {
                tag.DecreaseUsageCount();
            }

            await _tagRepository.UpdateAsync(tag);
        }
    }
}
