using ATMProject.Interfaces;
using System;

namespace ATMProject.Jobs
{
	public class MonthlyJob
	{
        private readonly IBank _bank;
		private readonly IConsoleManager _consoleManager;

		public MonthlyJob(IBank bank, IConsoleManager consoleManager)
        {
            _bank = bank;
			_consoleManager = consoleManager;
		}

        public void Execute()
        {
            _bank.ApplyMonthlyInterest();
            _bank.UpdatePlans();

            _consoleManager.WriteInfo("Monthly interest has been applied and user plans have been updated!");
        }
    }
}
