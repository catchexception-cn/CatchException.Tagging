using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace CatchException.Tagging.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(TaggingBlazorModule)
    )]
public class TaggingBlazorServerModule : AbpModule
{

}
