using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BiKe.Poetry.EntityFrameworkCore;
using BiKe.Poetry.Localization;
using BiKe.Poetry.Web.Menus;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Caching;
using Volo.Abp.AspNetCore.ExceptionHandling;
using System;
using Hangfire;
using Hangfire.PostgreSql;
using BiKe.Poetry.Event;
using BiKe.Poetry.Setting;
using BiKe.Poetry.Job;

namespace BiKe.Poetry.Web
{
    [DependsOn(
        typeof(PoetryHttpApiModule),
        typeof(PoetryApplicationModule),
        typeof(PoetryEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpCachingModule)
        )]
    public class PoetryWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(PoetryResource),
                    typeof(PoetryDomainModule).Assembly,
                    typeof(PoetryDomainSharedModule).Assembly,
                    typeof(PoetryApplicationModule).Assembly,
                    typeof(PoetryApplicationContractsModule).Assembly,
                    typeof(PoetryWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigurationSetting.ConnectionString = configuration["ConnectionStrings:Default"];

            ConfigureUrls(configuration);
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureNavigationServices();
            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
            ConfigureCAP(context.Services, configuration);
            ConfigureHangFire(context.Services, configuration);

            if (hostingEnvironment.IsDevelopment())
            {
                ConfigureException(context.Services);
            }
        }

        /// <summary>
        /// HangFire后台任务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private void ConfigureHangFire(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddHangfire(config =>
            //{
            //    config.UsePostgreSqlStorage(configuration["ConnectionStrings:Default"]);
            //});
            //Configure<AbpBackgroundJobWorkerOptions>(options =>
            //{
            //    options.DefaultTimeout = 864000; //10 days (as seconds)
            //});
            services.AddHangfire(c => c
                .UsePostgreSqlStorage(configuration["ConnectionStrings:Default"]));

            // Add the processing server as IHostedService
            services.AddHangfireServer();
        }

        /// <summary>
        /// CAP事件总线
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private void ConfigureCAP(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PoetryDbContext>(); //Options, If you are using EF as the ORM

            //事件配置
            services.AddTransient<TestEvent>();

            services.AddCap(x =>
            {
                // If you are using EF, you need to add the configuration：
                x.UseEntityFramework<PoetryDbContext>(); //Options, Notice: You don't need to config x.UseSqlServer(""") again! CAP can autodiscovery.

                x.UsePostgreSql(configuration["ConnectionStrings:Default"]);

                // CAP support RabbitMQ,Kafka,AzureService as the MQ, choose to add configuration you needed：
                x.UseRabbitMQ(options =>
                {
                    options.HostName = configuration["RabbitMQ:HostName"];
                    options.Port = Convert.ToInt32(configuration["RabbitMQ:Port"]);
                    options.UserName = configuration["RabbitMQ:UserName"];
                    options.Password = configuration["RabbitMQ:Password"];
                    //options.VirtualHost = configuration["RabbitMQ:VirtualHost"];
                });

                //仪表盘
                x.UseDashboard();
            });
        }

        /// <summary>
        /// 异常抛出
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureException(IServiceCollection services)
        {
            services.Configure<AbpExceptionHandlingOptions>(options =>
            {
                options.SendExceptionsDetailsToClients = true;
            });
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "Poetry";
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<PoetryWebModule>();

            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<PoetryDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}BiKe.Poetry.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<PoetryDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}BiKe.Poetry.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<PoetryApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}BiKe.Poetry.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<PoetryApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}BiKe.Poetry.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<PoetryWebModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            });
        }

        private void ConfigureNavigationServices()
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new PoetryMenuContributor());
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(PoetryApplicationModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Poetry API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }
        /// <summary>
        /// 后台工作者(定时任务)
        /// </summary>
        /// <param name="context"></param>
        private void AddBackgroundWorker(ApplicationInitializationContext context)
        {
            //context.AddBackgroundWorker<MyWorker>();
            HangFireJobRunner.Start();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            app.UseMultiTenancy();

            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Poetry API");
            });
            app.UseHangfireDashboard();
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();

            AddBackgroundWorker(context);
        }
    }
}
