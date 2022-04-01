using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CatchException.Tagging.EntityFrameworkCore;

[ConnectionStringName(TaggingDbProperties.ConnectionStringName)]
public interface ITaggingDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
