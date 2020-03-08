using System;
using System.Collections.Generic;
using System.Text;
using Wide.World.Importers.Localization;
using Volo.Abp.Application.Services;

namespace Wide.World.Importers
{
    /* Inherit your application services from this class.
     */
    public abstract class ImportersAppService : ApplicationService
    {
        protected ImportersAppService()
        {
            LocalizationResource = typeof(ImportersResource);
        }
    }
}
