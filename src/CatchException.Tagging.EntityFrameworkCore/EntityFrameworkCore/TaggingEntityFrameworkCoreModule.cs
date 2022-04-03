using CatchException.Tagging.Tagging;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CatchException.Tagging.EntityFrameworkCore;

[DependsOn(
    typeof(TaggingDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class TaggingEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<TaggingDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<Tag, EfCoreTagRepository>();
        });
    }
}
