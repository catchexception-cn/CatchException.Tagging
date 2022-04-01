using Volo.Abp.Reflection;

namespace CatchException.Tagging.Permissions;

public class TaggingPermissions
{
    public const string GroupName = "Tagging";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(TaggingPermissions));
    }
}
