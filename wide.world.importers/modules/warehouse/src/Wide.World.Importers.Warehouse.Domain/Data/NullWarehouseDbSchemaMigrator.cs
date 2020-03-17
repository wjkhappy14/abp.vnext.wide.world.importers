using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wide.World.Importers.Warehouse.Data
{
    /* This is used if database provider does't define
     * IWarehouseDbSchemaMigrator implementation.
     */
    public class NullWarehouseDbSchemaMigrator : IWarehouseDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}