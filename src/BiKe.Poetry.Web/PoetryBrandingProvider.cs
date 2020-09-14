using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace BiKe.Poetry.Web
{
    [Dependency(ReplaceServices = true)]
    public class PoetryBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Poetry";
    }
}
