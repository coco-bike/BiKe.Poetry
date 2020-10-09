using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace BiKe.Poetry.Job
{
    public class TestJob : BackgroundJob<string>, ITransientDependency
    {

        public TestJob()
        {

        }

        public override void Execute(string args)
        {
            Console.WriteLine(args);
        }

    }
}
