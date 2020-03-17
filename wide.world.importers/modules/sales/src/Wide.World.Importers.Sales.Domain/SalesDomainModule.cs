using Volo.Abp.Modularity;

namespace Wide.World.Importers.Sales
{
    [DependsOn(
        typeof(SalesDomainSharedModule)
        )]
    public class SalesDomainModule : AbpModule
    {

    }
}
