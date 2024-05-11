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

		public void ScanAndHandleCommands()
		{
            Console.WriteLine("");

            string input = Console.ReadLine();

			Console.Clear();

			CommandPrinter.PrintAllCommands();

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
			if (string.IsNullOrEmpty(commandName))
			{
				Console.WriteLine("Command name cannot be null or empty.");
				return;
			}

			if (!_commands.TryGetValue($"{commandName}Command", out Type commandType))
			{
				Console.WriteLine($"Command not found: {commandName}");
				return;
			}

			if (!typeof(ICommand).IsAssignableFrom(commandType))
			{
				Console.WriteLine($"Type {commandType} does not implement ICommand interface.");
				return;
			}

			var constructor = commandType.GetConstructors().FirstOrDefault();
			if (constructor == null)
			{
				Console.WriteLine($"Command {commandName} does not have a public constructor.");
				return;
			}

			var dependencies = constructor.GetParameters()
										   .Select(param => serviceProvider.GetService(param.ParameterType))
										   .ToArray();

			var command = Activator.CreateInstance(commandType, dependencies) as ICommand;
			if (command == null)
			{
				Console.WriteLine($"Failed to instantiate command: {commandName}");
				return;
			}

			try
			{
				command.Execute(parameters);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error executing command {commandName}: {ex.Message}");
			}
		}
	}
}
