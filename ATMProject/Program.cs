using ATMProject.Commands;
using ATMProject.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ATMProject
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//ServiceProvider serviceProvider = DependencyInjection.ConfigureServices();

			//GlobalConfiguration.Configuration.UseMemoryStorage();

			//CommandManager commandManager = serviceProvider.GetService<CommandManager>();

			//MonthlyJob ser = serviceProvider.GetService<MonthlyJob>();

			//RecurringJob.AddOrUpdate("MonthlyJob",() => ser.Execute(), Cron.Monthly);

			//commandManager.DiscoverCommands();

			//CommandPrinter.PrintAllCommands();

			//while (true)
			//{
			//	commandManager.Scan();
			//}

			var builder = new ConfigurationBuilder();

			var host = Host.CreateDefaultBuilder()
				.ConfigureServices(services => 
				{
					DependencyInjection.ConfigureServices(services);
				})
				.Build();

			var bootstrapper = ActivatorUtilities.CreateInstance<Bootstrapper>(host.Services);

			bootstrapper.Run();
		}
	}
}
