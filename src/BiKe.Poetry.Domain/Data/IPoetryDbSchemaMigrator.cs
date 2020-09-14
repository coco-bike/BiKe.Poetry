using System.Threading.Tasks;

namespace BiKe.Poetry.Data
{
    public interface IPoetryDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
