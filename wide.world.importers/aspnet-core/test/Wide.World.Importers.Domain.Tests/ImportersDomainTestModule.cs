using Wide.World.Importers.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Wide.World.Importers
{
    [DependsOn(
        typeof(ImportersEntityFrameworkCoreTestModule)
        )]
    public class ImportersDomainTestModule : AbpModule
    {

    }
}