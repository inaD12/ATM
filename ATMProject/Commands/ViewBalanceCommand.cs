using ATMProject.Results;
using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class ViewBalanceCommand : ICommand
	{
		private readonly IBank _bank;

		public ViewBalanceCommand(IBank bank)
		{
			_bank = bank;
		}
		public Result Execute(List<string> parameters)
		{
			if (parameters.Count != 1)
			{
				return Result.Failure("Invalid parameters!");
			}

			Result res = _bank.ViewBalance(parameters[0]);

			if (res.IsFailure)
				return res;

			return Result.Success($"{parameters[0]}'s balance is {(decimal)res.Object}");
        }
	}
}
