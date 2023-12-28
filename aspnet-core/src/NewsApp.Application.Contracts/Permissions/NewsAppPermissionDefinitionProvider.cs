using NewsApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NewsApp.Permissions;

public class NewsAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var NewsApp = context.AddGroup(NewsAppPermissions.GroupName);
        //Define your own permissions here. Example:
        NewsApp.AddPermission(NewsAppPermissions.Monitoreo.Default, L("Permission:Monitoreo"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NewsAppResource>(name);
    }
}
