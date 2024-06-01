using ATMProject.Results;
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
        public Result Execute(List<string> parameters)
		{
			decimal amount = 0;

			if (parameters.Count != 2 || !decimal.TryParse(parameters[1], out amount))
			{
				return Result.Failure(Strings.InvalidParams);
			}

			Result res = _bank.WithdrawMoney(parameters[0], amount);

			if (res.IsFailure) 
				return res;

            return Result.Success($"{amount} has successfully been withdrawn from {parameters[0]}'s wallet with the added tax of {(decimal)res.Object}!");
        }
	}
}
