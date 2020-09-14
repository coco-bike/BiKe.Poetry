using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace BiKe.Poetry
{
    public class PoetryWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<PoetryWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}