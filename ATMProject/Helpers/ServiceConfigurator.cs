using ATMProject.Factories;
using ATMProject.Helpers;
using ATMProject.Interfaces;
using ATMProject.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace ATMProject.Commands
{
    public static class ServiceConfigurator
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IBank, Bank>();
			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddTransient<IUserManager, UserManager>();
			services.AddTransient<IUserFactory, UserFactory>();
			services.AddTransient<ICommandManager, CommandManager>();
			services.AddTransient<IWithdrawalTaxManager, WithdrawalTaxManager>();
			services.AddTransient<ITaxCalculator, TaxCalculator>();
			services.AddTransient<ITaxPlanFactory, TaxPlanFactory>();
			services.AddTransient<MonthlyJob>();
			services.AddTransient<IConsoleManager, ConsoleManager>();
			services.AddTransient<Bootstrapper>();


			var commandTypes = Assembly.GetExecutingAssembly().GetTypes()
								   .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface);

			foreach (var type in commandTypes)
			{
				services.AddTransient(type);
			}

			services.AddHangfireServer();

			services.AddHangfire(x => x
				.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
				.UseSimpleAssemblyNameTypeSerializer()
				.UseRecommendedSerializerSettings()
				.UseMemoryStorage()
			);


			services.AddHostedService<HangfireHostedService>();
		}
	}

}
