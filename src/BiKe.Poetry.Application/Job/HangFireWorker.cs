using System;
using Hangfire;

namespace BiKe.Poetry.Job
{
    public static class HangFireWorker
    {
        public static void RunJob()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Hello world from HangFire!"), Cron.Minutely);
        }
    }
}
