using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;

namespace ATMProject
{
	public class CommandManager
	{
		public static Dictionary<string, Type> commands = new Dictionary<string, Type>();

		public void Scan()
		{
			string input = Console.ReadLine();

			string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			List<string> wordList = new List<string>(words);

			string command = words[0];

			List<string> parameters = wordList.Skip(1).ToList();

			ExecuteCommand(command, parameters);
		}

		public void DiscoverCommands()
		{
			var commandTypes = Assembly.GetExecutingAssembly().GetTypes()
									   .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface);
			foreach (var type in commandTypes)
			{
				string commandName = $"{type.Name}";
				commands[commandName] = type;
			}
		}

		public void ExecuteCommand(string commandName, List<string> parameters)
		{
			if (commands.TryGetValue($"{commandName}Command", out Type commandType))
			{
				ICommand command = Activator.CreateInstance(commandType) as ICommand;
				if (command != null)
				{
					command.Execute(parameters);
				}
				else
				{
					Console.WriteLine($"Failed to instantiate command: {commandName}");
				}
			}
			else
			{
				Console.WriteLine($"Command not found: {commandName}");
			}
		}
	}
}
