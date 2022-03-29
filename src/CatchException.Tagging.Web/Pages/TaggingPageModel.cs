using CatchException.Tagging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CatchException.Tagging.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TaggingPageModel : AbpPageModel
{
    protected TaggingPageModel()
    {
        LocalizationResourceType = typeof(TaggingResource);
        ObjectMapperContext = typeof(TaggingWebModule);
    }
}
