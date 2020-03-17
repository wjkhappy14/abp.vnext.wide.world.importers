using System.Threading.Tasks;

namespace Wide.World.Importers.Warehouse.Data
{
    public interface IWarehouseDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
