using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class CreateUserCommand : ICommand
	{
		private readonly Bank _bank;
        public CreateUserCommand(Bank bank)
        {
            _bank = bank;
        }
        public void Execute(List<string> parameters)
		{
			_bank.CreateUser(parameters[0], decimal.Parse(parameters[1]));
            Console.WriteLine($"User '{parameters[0]}' Successfully Created!");
        }
	}
}
