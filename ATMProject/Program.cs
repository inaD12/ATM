using ATMProject.Commands;
using ATMProject.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;

namespace ATMProject
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ServiceProvider serviceProvider = DependencyInjection.ConfigureServices();

			GlobalConfiguration.Configuration.UseMemoryStorage();

			CommandManager commandManager = serviceProvider.GetService<CommandManager>();

			MonthlyInterestJob ser = serviceProvider.GetRequiredService<MonthlyInterestJob>();

			RecurringJob.AddOrUpdate("MonthlyInterestJob",() => ser.Execute(), Cron.Monthly);

			commandManager.DiscoverCommands();

			while (true)
			{
				commandManager.Scan();
			}
		}
	}
}
