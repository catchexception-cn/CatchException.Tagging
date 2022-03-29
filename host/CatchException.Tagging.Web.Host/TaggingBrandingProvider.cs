using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace CatchException.Tagging;

[Dependency(ReplaceServices = true)]
public class TaggingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Tagging";
}
