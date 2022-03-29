using Volo.Abp.Modularity;

namespace CatchException.Tagging;

[DependsOn(
    typeof(TaggingApplicationModule),
    typeof(TaggingDomainTestModule)
    )]
public class TaggingApplicationTestModule : AbpModule
{

}
