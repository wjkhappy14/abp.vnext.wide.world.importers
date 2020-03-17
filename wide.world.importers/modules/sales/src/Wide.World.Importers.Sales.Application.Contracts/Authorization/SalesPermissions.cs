using Volo.Abp.Reflection;

namespace Wide.World.Importers.Sales.Authorization
{
    public class SalesPermissions
    {
        public const string GroupName = "Sales";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(SalesPermissions));
        }
    }
}