using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace CatchException.Tagging.Blazor.WebAssembly;

[DependsOn(
    typeof(TaggingBlazorModule),
    typeof(TaggingHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class TaggingBlazorWebAssemblyModule : AbpModule
{

}
