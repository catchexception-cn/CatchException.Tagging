using CatchException.Tagging.Localization;
using Volo.Abp.AspNetCore.Components;

namespace CatchException.Tagging.Blazor.Server.Host;

public abstract class TaggingComponentBase : AbpComponentBase
{
    protected TaggingComponentBase()
    {
        LocalizationResource = typeof(TaggingResource);
    }
}
