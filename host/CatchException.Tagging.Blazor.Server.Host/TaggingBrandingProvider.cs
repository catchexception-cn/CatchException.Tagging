using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CatchException.Tagging.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class TaggingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Tagging";
}
