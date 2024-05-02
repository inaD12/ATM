using ATMProject.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace ATMProject
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ServiceProvider serviceProvider = DependencyInjection.ConfigureServices();

			CommandManager commandManager = serviceProvider.GetService<CommandManager>();

			commandManager.DiscoverCommands();

			while (true)
			{
				commandManager.Scan();
			}
		}
	}
}
