using System;
using System.Collections.Generic;

namespace ATMProject.Commands
{
	internal class CheckPlanCommand : ICommand
	{
		private readonly Bank _bank;
		public CheckPlanCommand(Bank bank)
		{
			_bank = bank;
		}
		public void Execute(List<string> parameters)
		{
			if (parameters.Count != 1)
			{
				throw new ArgumentException("Invalid parameters!");
			}

			(PlanType, int) PlanAndWithdrawelsForThisMonth =_bank.CheckPlanType(parameters[0]);

			Console.WriteLine($"{parameters[0]}'s current plan is {PlanAndWithdrawelsForThisMonth.Item1} and their total withdrawals for this month is {PlanAndWithdrawelsForThisMonth.Item2}!");
        }
	}
}
