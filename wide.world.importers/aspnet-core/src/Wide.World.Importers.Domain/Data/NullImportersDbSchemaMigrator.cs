using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Wide.World.Importers.Data
{
    /* This is used if database provider does't define
     * IImportersDbSchemaMigrator implementation.
     */
    public class NullImportersDbSchemaMigrator : IImportersDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}