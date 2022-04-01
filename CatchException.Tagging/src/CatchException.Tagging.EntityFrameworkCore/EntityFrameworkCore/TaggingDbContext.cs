using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace CatchException.Tagging.EntityFrameworkCore;

[ConnectionStringName(TaggingDbProperties.ConnectionStringName)]
public class TaggingDbContext : AbpDbContext<TaggingDbContext>, ITaggingDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public TaggingDbContext(DbContextOptions<TaggingDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureTagging();
    }
}
