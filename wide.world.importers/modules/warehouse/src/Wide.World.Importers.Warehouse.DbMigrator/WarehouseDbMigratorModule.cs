using Wide.World.Importers.Warehouse.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Wide.World.Importers.Warehouse.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(WarehouseMongoDbModule),
        typeof(WarehouseApplicationContractsModule)
        )]
    public class WarehouseDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
