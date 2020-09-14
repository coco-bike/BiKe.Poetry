using System;
using System.Collections.Generic;
using System.Text;
using BiKe.Poetry.Localization;
using Volo.Abp.Application.Services;

namespace BiKe.Poetry
{
    /* Inherit your application services from this class.
     */
    public abstract class PoetryAppService : ApplicationService
    {
        protected PoetryAppService()
        {
            LocalizationResource = typeof(PoetryResource);
        }
    }
}
