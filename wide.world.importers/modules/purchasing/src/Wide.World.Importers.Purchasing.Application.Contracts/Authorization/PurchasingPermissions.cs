using Volo.Abp.Reflection;

namespace Wide.World.Importers.Purchasing.Authorization
{
    public class PurchasingPermissions
    {
        public const string GroupName = "Purchasing";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(PurchasingPermissions));
        }
    }
}