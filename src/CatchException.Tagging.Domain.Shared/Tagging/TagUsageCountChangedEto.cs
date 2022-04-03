using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace CatchException.Tagging.Tagging
{
    [Serializable]
    public class TagUsageCountChangedEto : EtoBase
    {
        public Guid Id { get; }

        public UsageCountEnum UsageCountEnum { get; }

        private TagUsageCountChangedEto()
        {
            //Default constructor is needed for deserialization.
        }
        public TagUsageCountChangedEto(Guid id, UsageCountEnum usageCountEnum)
        {
            Id = id;
            UsageCountEnum = usageCountEnum;
        }
    }

}
