using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace BiKe.Poetry.Job
{
    //public class MyWorker : AsyncPeriodicBackgroundWorkerBase
    //{
    //    public MyWorker(
    //        AbpTimer timer,
    //        IServiceScopeFactory serviceScopeFactory
    //    ) : base(
    //        timer,
    //        serviceScopeFactory)
    //    {
    //        Timer.Period = 600000; //10 minutes
    //    }


    //    protected override async Task DoWorkAsync(
    //    PeriodicBackgroundWorkerContext workerContext)
    //    {
    //        Logger.LogInformation("Starting: Setting status of inactive users...");

    //        //Resolve dependencie
    //        var authorService= workerContext.ServiceProvider.GetRequiredService<IAuthorAppService>();
    //        authorService.TestJob();
    //        //Do the work

    //        Logger.LogInformation("Completed: Setting status of inactive users...");
    //    }

    //    //public override Task StartAsync(CancellationToken cancellationToken = default)
    //    //{
    //    //    //...
    //    //}

    //    //public override Task StopAsync(CancellationToken cancellationToken = default)
    //    //{
    //    //    //...
    //    //}
    //}
}
