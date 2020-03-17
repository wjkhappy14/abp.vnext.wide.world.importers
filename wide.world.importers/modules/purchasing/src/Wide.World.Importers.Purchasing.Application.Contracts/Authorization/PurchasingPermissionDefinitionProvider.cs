using Wide.World.Importers.Purchasing.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Wide.World.Importers.Purchasing.Authorization
{
    public class PurchasingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(PurchasingPermissions.GroupName, L("Permission:Purchasing"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PurchasingResource>(name);
        }
    }
}