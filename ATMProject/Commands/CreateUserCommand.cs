using ATMProject.Results;
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
        public Result Execute(List<string> parameters)
		{
			decimal amount = 0;

			if (parameters.Count != 2 || !decimal.TryParse(parameters[1], out amount))
			{
				return Result.Failure("Invalid parameters!");
			}

			_bank.CreateUser(parameters[0], amount);

            return Result.Success($"User '{parameters[0]}' Successfully Created!");
        }
	}
}
