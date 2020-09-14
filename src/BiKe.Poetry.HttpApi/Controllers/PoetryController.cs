using BiKe.Poetry.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BiKe.Poetry.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class PoetryController : AbpController
    {
        protected PoetryController()
        {
            LocalizationResource = typeof(PoetryResource);
        }
    }
}