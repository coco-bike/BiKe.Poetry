using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace BiKe.Poetry.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(PoetryHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class PoetryConsoleApiClientModule : AbpModule
    {
        
    }
}
