using ATMProject.Results;
using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class TransferCommand : ICommand
	{
		private readonly IBank _bank;

		public TransferCommand(IBank bank)
		{
			_bank = bank;
		}
		public Result Execute(List<string> parameters)
		{
			decimal amount = 0;

			if (parameters.Count != 3 || !decimal.TryParse(parameters[2], out amount))
			{
				return Result.Failure("Invalid parameters!");
			}

			Result res = _bank.TransferMoney(parameters[0], parameters[1], amount);

			if (res.IsFailure)
				return res;

           return Result.Success($"{amount} has been transfered from '{parameters[0]}' to '{parameters[1]}' and a tax of {(decimal)res.Object} was taken!");
        }
	}
}
