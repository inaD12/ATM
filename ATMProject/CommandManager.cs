using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ATMProject
{
	public class CommandManager
	{
		private Dictionary<string, Type> _commands = new Dictionary<string, Type>();
		private readonly IServiceProvider _serviceProvider;

		public CommandManager(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void Scan()
		{
			string input = Console.ReadLine();

			string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			List<string> wordList = new List<string>(words);

			string command = words[0];

			List<string> parameters = wordList.Skip(1).ToList();

			ExecuteCommand(command, parameters, _serviceProvider);
		}

		public void DiscoverCommands()
		{
			var commandTypes = Assembly.GetExecutingAssembly().GetTypes()
									   .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface);
			foreach (var type in commandTypes)
			{
				string commandName = $"{type.Name}";
				_commands[commandName] = type;
			}
		}

		private void ExecuteCommand(string commandName, List<string> parameters, IServiceProvider serviceProvider)
		{
			if (_commands.TryGetValue($"{commandName}Command", out Type commandType))
			{
				if (typeof(ICommand).IsAssignableFrom(commandType))
				{
					var dependencies = new List<object>();
					foreach (var constructorParam in commandType.GetConstructors()[0].GetParameters())
					{
						dependencies.Add(serviceProvider.GetRequiredService(constructorParam.ParameterType));
					}

					ICommand command = Activator.CreateInstance(commandType, dependencies.ToArray()) as ICommand;
					if (command != null)
					{
						try
						{
							command.Execute(parameters);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
					else
					{
						Console.WriteLine($"Failed to instantiate command: {commandName}");
					}
				}
				else
				{
					Console.WriteLine($"Type {commandType} does not implement ICommand interface.");
				}
			}
			else
			{
				Console.WriteLine($"Command not found: {commandName}");
			}
		}
	}
}
