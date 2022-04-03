using CatchException.Tagging.Tagging;

using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;

namespace CatchException.Tagging;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpAutoMapperModule),
    typeof(TaggingDomainSharedModule)
)]
public class TaggingDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<TaggingDomainModule>();
        
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<TaggingDomainMappingProfile>(validate: true);
        });

        Configure<AbpDistributedEntityEventOptions>(options =>
        {
            options.EtoMappings.Add<Tag, TagEto>(typeof(TaggingDomainModule));

            options.AutoEventSelectors.Add<Tag>();
        });
    }

}
