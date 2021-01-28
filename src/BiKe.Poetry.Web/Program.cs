using System;
using BiKe.Poetry.Setting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace BiKe.Poetry.Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            #region 配置文件
//            var builder = new ConfigurationBuilder()

//#if DEBUG
//                .AddJsonFile("appsettings.Development.json");
//#else
//                .AddJsonFile("appsettings.Production.json");
//#endif



//            var configuration = builder.Build();
//            ConfigurationSetting.ElasticConfigurationUrl = configuration["ElasticConfiguration:Uri"];
            #endregion

            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.Console())
                //ELK日志收集
                //.WriteTo.Elasticsearch(
                //    new ElasticsearchSinkOptions(new Uri(ConfigurationSetting.ElasticConfigurationUrl))
                //    {
                //        MinimumLogEventLevel = LogEventLevel.Verbose,
                //        AutoRegisterTemplate = true
                //    })
                .CreateLogger();

            try
            {
                Log.Information("Starting web host.");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseAutofac()
                .UseSerilog();
    }
}
