using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
// ReSharper disable VirtualMemberCallInConstructor

namespace CatchException.Tagging.Tagging
{
    public class Tag : FullAuditedAggregateRoot<Guid>
    {

        public virtual string Name { get; protected set; } = default!;

        public virtual string Description { get; protected set; } = default!;

        public virtual int UsageCount { get; protected internal set; }

        protected Tag()
        {

        }

        public Tag(Guid id, string name, int usageCount = 0, string description = "")
            : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = description;
            UsageCount = usageCount;
        }

        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public virtual void SetDescription(string description)
        {
            Description = description;
        }

        public virtual void IncreaseUsageCount(int number = 1)
        {
            UsageCount += number;
        }

        public virtual void DecreaseUsageCount(int number = 1)
        {
            if (UsageCount <= 0)
            {
                return;
            }

            if (UsageCount - number <= 0)
            {
                UsageCount = 0;
                return;
            }

            UsageCount -= number;
        }
    }
}
