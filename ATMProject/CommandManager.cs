using ATMProject.Interfaces;
using ATMProject.Results;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ATMProject
{
	public class CommandManager
	{
		private readonly Dictionary<string, Type> _commands = new Dictionary<string, Type>();
		private readonly IServiceProvider _serviceProvider;
		private readonly IConsoleManager _consoleManager;

		public CommandManager(IServiceProvider serviceProvider, IConsoleManager consoleManager)
		{
			_serviceProvider = serviceProvider;
			_consoleManager = consoleManager;
		}

		public void Scan()
		{
			string input = _consoleManager.ReadLine();
			_consoleManager.ClearConsole();
			_consoleManager.PrintAllCommands();
			HandleCommand(input);

			Scan();
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

		private void HandleCommand(string input)
		{
			string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			if (words.Length == 0)
			{
				_consoleManager.WriteError("Command name cannot be null or empty.");
				return;
			}

			List<string> wordList = new List<string>(words);
			string command = words[0];
			List<string> parameters = wordList.Skip(1).ToList();

			ExecuteCommand(command, parameters);
		}

		private void ExecuteCommand(string commandName, List<string> parameters)
		{
			if (!_commands.TryGetValue($"{commandName}Command", out Type commandType))
			{
				_consoleManager.WriteError($"Command not found: {commandName}");
				return;
			}

			try
			{
				using (var scope = _serviceProvider.CreateScope())
				{
					var command = scope.ServiceProvider.GetRequiredService(commandType) as ICommand;
					if (command == null)
					{
						_consoleManager.WriteError($"Failed to instantiate command: {commandName}");
						return;
					}

					Result res = command.Execute(parameters);

					if (res.IsFailure)
					{
						_consoleManager.WriteError(res.Description);
					}
					else
					{
						_consoleManager.WriteInfo(res.Description);
					}
				}
			}
			catch (Exception ex)
			{
				_consoleManager.WriteError($"Error executing command {commandName}: {ex.Message}");
			}
		}
	}
}
