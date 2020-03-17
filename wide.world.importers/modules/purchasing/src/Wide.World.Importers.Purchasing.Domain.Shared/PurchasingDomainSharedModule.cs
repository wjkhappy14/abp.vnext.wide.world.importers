using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Wide.World.Importers.Purchasing.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Wide.World.Importers.Purchasing
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class PurchasingDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<PurchasingDomainSharedModule>("Wide.World.Importers.Purchasing");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<PurchasingResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Purchasing");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Purchasing", typeof(PurchasingResource));
            });
        }
    }
}
