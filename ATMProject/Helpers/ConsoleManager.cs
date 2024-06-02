using System;
using ATMProject.Interfaces;

namespace ATMProject.Helpers
{
    public class ConsoleManager : IConsoleManager
	{
		public void WriteInfo(string message)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"{message}");
			Console.ResetColor();
			WriteEmptyLine();
		}

		public void WriteError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"{message}");
			Console.ResetColor();
			WriteEmptyLine();
		}

		public void WriteEmptyLine()
		{
            Console.WriteLine("");
        }

		public void ClearConsole()
		{
			Console.Clear(); 
		}

		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public void PrintAllCommands()
		{
            Console.WriteLine(Strings.AllCommands);
        }
	}
}
