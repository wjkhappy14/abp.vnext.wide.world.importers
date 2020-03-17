namespace Wide.World.Importers.Purchasing
{
    public static class PurchasingDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Purchasing";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Purchasing";
    }
}
