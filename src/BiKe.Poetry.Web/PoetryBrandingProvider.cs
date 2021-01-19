using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BiKe.Poetry.Web
{
    [Dependency(ReplaceServices = true)]
    public class PoetryBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Poetry";
    }
}
