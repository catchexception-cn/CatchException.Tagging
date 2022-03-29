using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CatchException.Tagging.EntityFrameworkCore;

public class TaggingHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<TaggingHttpApiHostMigrationsDbContext>
{
    public TaggingHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<TaggingHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Tagging"));

        return new TaggingHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
