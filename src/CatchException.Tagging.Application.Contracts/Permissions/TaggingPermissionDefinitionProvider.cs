using CatchException.Tagging.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CatchException.Tagging.Permissions;

public class TaggingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TaggingPermissions.GroupName, L("Permission:Tagging"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TaggingResource>(name);
    }
}
