using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace CatchException.Tagging;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(TaggingDomainSharedModule)
)]
public class TaggingDomainModule : AbpModule
{

}
