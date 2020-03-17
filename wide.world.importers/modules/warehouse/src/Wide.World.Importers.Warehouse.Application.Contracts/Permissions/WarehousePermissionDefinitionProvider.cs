using Wide.World.Importers.Warehouse.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Wide.World.Importers.Warehouse.Permissions
{
    public class WarehousePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(WarehousePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(WarehousePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<WarehouseResource>(name);
        }
    }
}
