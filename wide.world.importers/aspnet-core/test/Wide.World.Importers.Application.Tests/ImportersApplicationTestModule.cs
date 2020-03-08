using Volo.Abp.Modularity;

namespace Wide.World.Importers
{
    [DependsOn(
        typeof(ImportersApplicationModule),
        typeof(ImportersDomainTestModule)
        )]
    public class ImportersApplicationTestModule : AbpModule
    {

    }
}