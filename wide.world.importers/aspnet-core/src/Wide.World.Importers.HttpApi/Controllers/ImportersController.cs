using Wide.World.Importers.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Wide.World.Importers.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ImportersController : AbpController
    {
        protected ImportersController()
        {
            LocalizationResource = typeof(ImportersResource);
        }
    }
}