using System.Threading.Tasks;

namespace Wide.World.Importers.Data
{
    public interface IImportersDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
