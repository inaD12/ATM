using ATMProject.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ATMProject.Helpers
{
    public class HangfireHostedService : IHostedService
    {
        private readonly IRecurringJobManager _recurringJobManager;

        public HangfireHostedService(IRecurringJobManager recurringJobManager)
        {
            _recurringJobManager = recurringJobManager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            GlobalConfiguration.Configuration
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage();

            //Cron for 5 seconds - "*/5 * * * * *"
            _recurringJobManager.AddOrUpdate<MonthlyJob>("MonthlyJob", job => job.Execute(), Cron.Monthly);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}