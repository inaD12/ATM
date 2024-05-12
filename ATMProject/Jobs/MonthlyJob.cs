using System;

namespace ATMProject.Jobs
{
	public class MonthlyJob
	{
        private readonly IBank _bank;
        public MonthlyJob(IBank bank)
        {
            _bank = bank;
        }

        public void Execute()
        {
            _bank.ApplyMonthlyInterest();
            _bank.UpdatePlans();
            Console.WriteLine("Monthly interest has been applied and user plans have been updated!");
        }
    }
}
