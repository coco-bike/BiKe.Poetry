using BiKe.Poetry.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BiKe.Poetry.Permissions
{
    public class PoetryPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(PoetryPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(PoetryPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PoetryResource>(name);
        }
    }
}
