using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class TransferCommand : ICommand
	{
		private readonly Bank _bank;

		public TransferCommand(Bank bank)
		{
			_bank = bank;
		}
		public void Execute(List<string> parameters)
		{
			decimal amount = 0;

			if (parameters.Count != 3 || !decimal.TryParse(parameters[2], out amount))
			{
				throw new ArgumentException("Invalid parameters!");
			}

			_bank.TransferMoney(parameters[0], parameters[1], amount);

            Console.WriteLine($"{amount} has been transfered from '{parameters[0]}' to '{parameters[1]}'!");
        }
	}
}
