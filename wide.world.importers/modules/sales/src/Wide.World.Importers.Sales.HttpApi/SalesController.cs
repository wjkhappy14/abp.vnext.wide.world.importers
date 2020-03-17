using Wide.World.Importers.Sales.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wide.World.Importers.Sales
{
    public abstract class SalesController : AbpController
    {
        protected SalesController()
        {
            LocalizationResource = typeof(SalesResource);
        }
    }
}
