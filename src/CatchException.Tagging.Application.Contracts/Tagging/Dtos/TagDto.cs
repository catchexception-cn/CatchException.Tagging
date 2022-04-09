using Volo.Abp.Application.Dtos;

namespace CatchException.Tagging.Tagging.Dtos
{
    public class TagDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int UsageCount { get; set; }
    }
}