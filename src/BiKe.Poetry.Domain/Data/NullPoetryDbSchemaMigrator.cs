using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BiKe.Poetry.Data
{
    /* This is used if database provider does't define
     * IPoetryDbSchemaMigrator implementation.
     */
    public class NullPoetryDbSchemaMigrator : IPoetryDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}