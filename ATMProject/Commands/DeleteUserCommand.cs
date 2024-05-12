using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class DeleteUserCommand : ICommand
	{
		private readonly IBank _bank;

        public DeleteUserCommand(IBank bank)
        {
            _bank = bank;
        }
        public void Execute(List<string> parameters)
		{
			if (parameters.Count != 1)
			{
				throw new ArgumentException("Invalid parameters!");
			}

			_bank.RemoveUser(parameters[0]);

            Console.WriteLine($"User {parameters[0]} successfully deleted!");
        }
	}
}
