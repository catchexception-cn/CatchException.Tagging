using Localization.Resources.AbpUi;
using CatchException.Tagging.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace CatchException.Tagging;

[DependsOn(
    typeof(TaggingApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class TaggingHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TaggingHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<TaggingResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
