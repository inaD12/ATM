using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class CreateUserCommand : ICommand
	{
		private readonly IBank _bank;
        public CreateUserCommand(IBank bank)
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

			_bank.CreateUser(parameters[0], amount);
            Console.WriteLine($"User '{parameters[0]}' Successfully Created!");
        }
	}
}
