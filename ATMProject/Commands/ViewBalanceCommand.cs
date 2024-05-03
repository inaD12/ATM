using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class ViewBalanceCommand : ICommand
	{
		private readonly Bank _bank;

		public ViewBalanceCommand(Bank bank)
		{
			_bank = bank;
		}
		public void Execute(List<string> parameters)
		{
			if (parameters.Count != 1)
			{
				throw new ArgumentException("Invalid parameters!");
			}

			decimal balance = _bank.ViewBalance(parameters[0]);

			Console.WriteLine($"{parameters[0]}'s balance is {balance}");
        }
	}
}
