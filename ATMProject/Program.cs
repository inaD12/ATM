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

			MonthlyJob ser = serviceProvider.GetService<MonthlyJob>();

			RecurringJob.AddOrUpdate("MonthlyJob",() => ser.Execute(), Cron.Monthly);

			commandManager.DiscoverCommands();

			CommandPrinter.PrintAllCommands();

			while (true)
			{
				commandManager.ScanAndHandleCommands();
			}
		}
	}
}
