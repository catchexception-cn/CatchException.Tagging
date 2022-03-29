using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace CatchException.Tagging;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TaggingHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class TaggingConsoleApiClientModule : AbpModule
{

}
