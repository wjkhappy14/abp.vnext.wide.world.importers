using Localization.Resources.AbpUi;
using Wide.World.Importers.Purchasing.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Wide.World.Importers.Purchasing
{
    [DependsOn(
        typeof(PurchasingApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class PurchasingHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(PurchasingHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<PurchasingResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
