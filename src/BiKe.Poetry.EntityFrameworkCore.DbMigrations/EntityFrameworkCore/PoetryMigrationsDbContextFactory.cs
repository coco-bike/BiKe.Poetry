using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BiKe.Poetry.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class PoetryMigrationsDbContextFactory : IDesignTimeDbContextFactory<PoetryMigrationsDbContext>
    {
        public PoetryMigrationsDbContext CreateDbContext(string[] args)
        {
            PoetryEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<PoetryMigrationsDbContext>()
                .UseNpgsql(configuration.GetConnectionString("Default"));

            return new PoetryMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BiKe.Poetry.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
