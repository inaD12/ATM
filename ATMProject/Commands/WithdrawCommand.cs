using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class WithdrawCommand : ICommand
	{
		private readonly IBank _bank;

        public WithdrawCommand(IBank bank)
        {
            _bank = bank;
        }
        public void Execute(List<string> parameters)
		{
			decimal amount = 0;

			if (parameters.Count != 2 || !decimal.TryParse(parameters[1], out amount))
			{
				throw new ArgumentException("Invalid parameters!");
			}

			decimal tax = _bank.WithdrawMoney(parameters[0], amount);

            Console.WriteLine($"{amount} has successfully been withdrawn from {parameters[0]}'s wallet with the added tax of {tax}!");
        }
	}
}
