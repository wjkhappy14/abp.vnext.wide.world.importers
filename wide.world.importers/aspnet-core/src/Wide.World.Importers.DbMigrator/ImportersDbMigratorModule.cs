using Wide.World.Importers.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Wide.World.Importers.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ImportersEntityFrameworkCoreDbMigrationsModule),
        typeof(ImportersApplicationContractsModule)
        )]
    public class ImportersDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
