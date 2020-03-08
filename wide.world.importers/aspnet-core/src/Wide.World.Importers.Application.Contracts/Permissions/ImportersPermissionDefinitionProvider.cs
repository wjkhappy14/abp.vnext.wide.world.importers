using Wide.World.Importers.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Wide.World.Importers.Permissions
{
    public class ImportersPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ImportersPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ImportersPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ImportersResource>(name);
        }
    }
}
