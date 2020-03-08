using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Wide.World.Importers.EntityFrameworkCore
{
    [DependsOn(
        typeof(ImportersEntityFrameworkCoreModule)
        )]
    public class ImportersEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ImportersMigrationsDbContext>();
        }
    }
}
