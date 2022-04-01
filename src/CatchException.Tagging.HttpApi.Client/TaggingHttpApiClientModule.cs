using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace CatchException.Tagging;

[DependsOn(
    typeof(TaggingApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class TaggingHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(TaggingApplicationContractsModule).Assembly,
            TaggingRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TaggingHttpApiClientModule>();
        });

    }
}
