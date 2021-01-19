using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Identity.Settings;

namespace BiKe.Poetry.Job
{
    public static class HangFireJobRunner
    {
        public static void Start()
        {
            //string jobId =
            //    BackgroundJob.Schedule<string>(m =>  "2"),
            //        TimeSpan.FromMinutes(2));
            //BackgroundJob.ContinueJobWith<TestHangfireJob>(m => m.GetUserCount());
            RecurringJob.AddOrUpdate<TestHangfireJob>(m => m.GetUserCount(), Cron.Minutely, TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate<TestHangfireJob>(m => m.LockUser2(), Cron.Minutely, TimeZoneInfo.Local);
        }

        public class TestHangfireJob
        {
            private readonly IServiceProvider _provider;

            /// <summary>
            /// 初始化一个<see cref="TestHangfireJob"/>类型的新实例
            /// </summary>
            public TestHangfireJob(IServiceProvider provider)
            {
                _provider = provider;
            }

            /// <summary>
            /// 获取用户数量
            /// </summary>
            public void GetUserCount()
            {
                Console.WriteLine("测试1");
            }

            public void LockUser2()
            {
                Console.WriteLine("测试2");
            }
        }
    }
}
