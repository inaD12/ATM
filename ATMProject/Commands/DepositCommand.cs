using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class DepositCommand : ICommand
	{
		private readonly Bank _bank;

		public DepositCommand(Bank bank)
		{
			_bank = bank;
		}

		public void Execute(List<string> parameters)
		{
			decimal amount = 0;

			if (parameters.Count != 2 || !decimal.TryParse(parameters[1],out amount))
			{
				throw new ArgumentException("Invalid parameters!");
			}

			_bank.DepositMoney(parameters[0], amount);

			Console.WriteLine($"{amount} has successfully been deposited in {parameters[0]}'s wallet!");
		}
	}
}
