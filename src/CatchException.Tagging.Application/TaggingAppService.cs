using CatchException.Tagging.Localization;
using Volo.Abp.Application.Services;

namespace CatchException.Tagging;

public abstract class TaggingAppService : ApplicationService
{
    protected TaggingAppService()
    {
        LocalizationResource = typeof(TaggingResource);
        ObjectMapperContext = typeof(TaggingApplicationModule);
    }
}
