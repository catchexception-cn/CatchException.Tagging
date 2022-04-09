using Volo.Abp.Bundling;

namespace CatchException.Tagging.Blazor.Bundles;

public class TaggingBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {
        context.Add("_content/CatchException.Tagging.Blazor/libs/tagify/tagify.min.js");
        context.Add("_content/CatchException.Tagging.Blazor/libs/tagify/tagify.polyfills.min.js");
    }

    public void AddStyles(BundleContext context)
    {
        context.Add("_content/CatchException.Tagging.Blazor/libs/tagify/tagify.css");
    }
}