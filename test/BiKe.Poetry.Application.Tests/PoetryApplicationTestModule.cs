using Volo.Abp.Modularity;

namespace BiKe.Poetry
{
    [DependsOn(
        typeof(PoetryApplicationModule),
        typeof(PoetryDomainTestModule)
        )]
    public class PoetryApplicationTestModule : AbpModule
    {

    }
}