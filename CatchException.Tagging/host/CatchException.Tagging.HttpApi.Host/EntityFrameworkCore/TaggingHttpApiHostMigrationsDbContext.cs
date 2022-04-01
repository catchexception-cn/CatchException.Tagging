using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace CatchException.Tagging.EntityFrameworkCore;

public class TaggingHttpApiHostMigrationsDbContext : AbpDbContext<TaggingHttpApiHostMigrationsDbContext>
{
    public TaggingHttpApiHostMigrationsDbContext(DbContextOptions<TaggingHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureTagging();
    }
}
