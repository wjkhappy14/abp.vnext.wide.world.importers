using Wide.World.Importers.Warehouse.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wide.World.Importers.Warehouse.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class WarehouseController : AbpController
    {
        protected WarehouseController()
        {
            LocalizationResource = typeof(WarehouseResource);
        }
    }
}