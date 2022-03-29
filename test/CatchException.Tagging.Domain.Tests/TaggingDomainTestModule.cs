using CatchException.Tagging.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CatchException.Tagging;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(TaggingEntityFrameworkCoreTestModule)
    )]
public class TaggingDomainTestModule : AbpModule
{

}
