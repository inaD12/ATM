using ATMProject.Factories;
using ATMProject.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;

namespace ATMProject.Commands
{
	public static class DependencyInjection
	{
		public static ServiceProvider ConfigureServices()
		{
			ServiceCollection services = new ServiceCollection();

			services.AddSingleton<Bank>();
			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddTransient<IUserManager, UserManager>();
			services.AddTransient<IUserFactory, UserFactory>();
			services.AddTransient<CommandManager>();
			services.AddTransient<IWithdrawalTaxManager, WithdrawalTaxManager>();
			services.AddTransient<ITaxCalculator, TaxCalculator>();
			services.AddTransient<ITaxPlanFactory, TaxPlanFactory>();
			services.AddTransient<MonthlyJob>();

			services.AddHangfire(x => x
			.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
			.UseSimpleAssemblyNameTypeSerializer()
			.UseRecommendedSerializerSettings()
			.UseMemoryStorage()
			);

			services.AddHangfireServer();

			return services.BuildServiceProvider();
		}
	}
}
