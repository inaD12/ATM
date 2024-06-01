using ATMProject.Commands;
using ATMProject.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ATMProject
{
    internal class Program
	{
		static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder();

			var host = Host.CreateDefaultBuilder()
				.ConfigureLogging(logging =>
				{
					logging.ClearProviders();
				})
				.ConfigureServices(services => 
				{
					DependencyInjection.ConfigureServices(services);
				})
				.Build();

			var bootstrapper = ActivatorUtilities.CreateInstance<Bootstrapper>(host.Services);


			Task.Run(() => bootstrapper.Run());

			host.Run();
		}
	}
}
