using ATMProject.Factories;
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


			return services.BuildServiceProvider();
		}
	}
}
