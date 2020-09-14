using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace BiKe.Poetry.EntityFrameworkCore
{
    [DependsOn(
        typeof(PoetryEntityFrameworkCoreModule)
        )]
    public class PoetryEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PoetryMigrationsDbContext>();
        }
    }
}
