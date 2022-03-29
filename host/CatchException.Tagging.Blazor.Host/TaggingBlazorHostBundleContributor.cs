using Volo.Abp.Bundling;

namespace CatchException.Tagging.Blazor.Host;

public class TaggingBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
