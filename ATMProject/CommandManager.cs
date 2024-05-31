using ATMProject.Interfaces;
using ATMProject.Results;
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
		private readonly IConsoleManager _consoleManager;

		public CommandManager(IServiceProvider serviceProvider, IConsoleManager consoleWriter)
		{
			_serviceProvider = serviceProvider;
			_consoleManager = consoleWriter;
		}

		public void Scan()
		{
			_consoleManager.WriteEmptyLine();

            string input = Console.ReadLine();

			_consoleManager.ClearConsole();

			CommandPrinter.PrintAllCommands();

			HandleCommand(input);
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

			List<string> wordList = new List<string>(words);

			string command = words[0];

			List<string> parameters = wordList.Skip(1).ToList();

			ExecuteCommand(command, parameters, _serviceProvider);
		}

		private void ExecuteCommand(string commandName, List<string> parameters, IServiceProvider serviceProvider)
		{
			if (string.IsNullOrEmpty(commandName))
			{
				_consoleManager.WriteError("Command name cannot be null or empty.");
				return;
			}

			if (!_commands.TryGetValue($"{commandName}Command", out Type commandType))
			{
				_consoleManager.WriteError($"Command not found: {commandName}");
				return;
			}

			if (!typeof(ICommand).IsAssignableFrom(commandType))
			{
				_consoleManager.WriteError($"Type {commandType} does not implement ICommand interface.");
				return;
			}

			var constructor = commandType.GetConstructors().FirstOrDefault();
			if (constructor == null)
			{
				_consoleManager.WriteError($"Command {commandName} does not have a public constructor.");
				return;
			}

			var dependencies = constructor.GetParameters()
										   .Select(param => serviceProvider.GetService(param.ParameterType))
										   .ToArray();

			var command = Activator.CreateInstance(commandType, dependencies) as ICommand;
			if (command == null)
			{
				_consoleManager.WriteError($"Failed to instantiate command: {commandName}");
				return;
			}

			try
			{
				Result res = command.Execute(parameters);

				if (res.IsFailure)
					_consoleManager.WriteError(res.Description);
				else
					_consoleManager.WriteInfo(res.Description);

			}
			catch (Exception ex)
			{
				_consoleManager.WriteError($"Error executing command {commandName}: {ex.Message}");
			}
		}
	}
}
