using BiKe.Poetry.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BiKe.Poetry.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class PoetryPageModel : AbpPageModel
    {
        protected PoetryPageModel()
        {
            LocalizationResourceType = typeof(PoetryResource);
        }
    }
}