using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wide.World.Importers.Data;
using Volo.Abp.DependencyInjection;

namespace Wide.World.Importers.EntityFrameworkCore
{
    public class EntityFrameworkCoreImportersDbSchemaMigrator
        : IImportersDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreImportersDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ImportersMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ImportersMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}