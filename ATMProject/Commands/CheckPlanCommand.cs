using ATMProject.Results;
using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class CheckPlanCommand : ICommand
	{
		private readonly IBank _bank;
		public CheckPlanCommand(IBank bank)
		{
			_bank = bank;
		}
		public Result Execute(List<string> parameters)
		{
			if (parameters.Count != 1)
			{
				return Result.Failure("Invalid parameters!");
			}

			(PlanType, int) PlanAndWithdrawelsForThisMonth = ((PlanType, int))_bank.CheckPlanType(parameters[0]).Object;

			return Result.Success($"{parameters[0]}'s current plan is {PlanAndWithdrawelsForThisMonth.Item1} and their total withdrawals for this month is {PlanAndWithdrawelsForThisMonth.Item2}!");
        }
	}
}
