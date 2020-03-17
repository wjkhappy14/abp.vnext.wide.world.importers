using System;
using System.Collections.Generic;
using System.Text;
using Wide.World.Importers.Warehouse.Localization;
using Volo.Abp.Application.Services;

namespace Wide.World.Importers.Warehouse
{
    /* Inherit your application services from this class.
     */
    public abstract class WarehouseAppService : ApplicationService
    {
        protected WarehouseAppService()
        {
            LocalizationResource = typeof(WarehouseResource);
        }
    }
}
