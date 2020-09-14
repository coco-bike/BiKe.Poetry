using BiKe.Poetry.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BiKe.Poetry
{
    [DependsOn(
        typeof(PoetryEntityFrameworkCoreTestModule)
        )]
    public class PoetryDomainTestModule : AbpModule
    {

    }
}