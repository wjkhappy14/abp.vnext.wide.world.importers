using Wide.World.Importers.Sales.Localization;
using Volo.Abp.Application.Services;

namespace Wide.World.Importers.Sales
{
    public abstract class SalesAppService : ApplicationService
    {
        protected SalesAppService()
        {
            LocalizationResource = typeof(SalesResource);
            ObjectMapperContext = typeof(SalesApplicationModule);
        }
    }
}
