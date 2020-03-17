using Wide.World.Importers.Purchasing.Localization;
using Volo.Abp.Application.Services;

namespace Wide.World.Importers.Purchasing
{
    public abstract class PurchasingAppService : ApplicationService
    {
        protected PurchasingAppService()
        {
            LocalizationResource = typeof(PurchasingResource);
            ObjectMapperContext = typeof(PurchasingApplicationModule);
        }
    }
}
