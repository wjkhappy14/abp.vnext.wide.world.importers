using Volo.Abp.Modularity;

namespace Wide.World.Importers.Purchasing
{
    [DependsOn(
        typeof(PurchasingDomainSharedModule)
        )]
    public class PurchasingDomainModule : AbpModule
    {

    }
}
