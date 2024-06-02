using ATMProject.Results;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class DepositCommand : ICommand
	{
		private readonly IBank _bank;

		public DepositCommand(IBank bank)
		{
			_bank = bank;
		}

		public Result Execute(List<string> parameters)
		{
			decimal amount = 0;

			if (parameters.Count != 2 || !decimal.TryParse(parameters[1],out amount))
			{
				return Result.Failure(Strings.InvalidParams);
			}

			Result res = _bank.DepositMoney(parameters[0], amount);

			if (res.IsFailure)
				return res;

			return Result.Success($"{amount} has successfully been deposited in {parameters[0]}'s wallet!");
		}
	}
}
