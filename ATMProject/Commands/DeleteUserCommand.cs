using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class DeleteUserCommand : ICommand
	{
		private readonly Bank _bank;

        public DeleteUserCommand(Bank bank)
        {
            _bank = bank;
        }
        public void Execute(List<string> parameters)
		{
			_bank.RemoveUser(parameters[0]);

            Console.WriteLine($"User {parameters[0]} successfully deleted!");
        }
	}
}
