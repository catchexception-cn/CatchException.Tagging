using CatchException.Tagging.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CatchException.Tagging;

public abstract class TaggingController : AbpControllerBase
{
    protected TaggingController()
    {
        LocalizationResource = typeof(TaggingResource);
    }
}
