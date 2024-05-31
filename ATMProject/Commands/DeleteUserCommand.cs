using ATMProject.Results;
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
        public Result Execute(List<string> parameters)
		{
			if (parameters.Count != 1)
			{
				return Result.Failure("Invalid parameters!");
			}

			_bank.RemoveUser(parameters[0]);

            return Result.Success($"User {parameters[0]} successfully deleted!");
        }
	}
}
