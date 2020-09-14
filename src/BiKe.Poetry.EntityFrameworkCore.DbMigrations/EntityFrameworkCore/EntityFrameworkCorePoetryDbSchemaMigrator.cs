using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BiKe.Poetry.Data;
using Volo.Abp.DependencyInjection;

namespace BiKe.Poetry.EntityFrameworkCore
{
    public class EntityFrameworkCorePoetryDbSchemaMigrator
        : IPoetryDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCorePoetryDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the PoetryMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<PoetryMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}