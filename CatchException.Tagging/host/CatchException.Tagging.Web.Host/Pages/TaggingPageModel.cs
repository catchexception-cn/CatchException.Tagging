using CatchException.Tagging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CatchException.Tagging.Pages;

public abstract class TaggingPageModel : AbpPageModel
{
    protected TaggingPageModel()
    {
        LocalizationResourceType = typeof(TaggingResource);
    }
}
