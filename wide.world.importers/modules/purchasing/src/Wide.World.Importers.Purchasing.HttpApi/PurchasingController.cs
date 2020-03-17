using Wide.World.Importers.Purchasing.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wide.World.Importers.Purchasing
{
    public abstract class PurchasingController : AbpController
    {
        protected PurchasingController()
        {
            LocalizationResource = typeof(PurchasingResource);
        }
    }
}
