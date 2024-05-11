using System;

namespace ATMProject.Jobs
{
	public class MonthlyJob
	{
        private readonly Bank _bank;
        public MonthlyJob(Bank bank)
        {
            _bank = bank;
        }

        public void Execute()
        {
            _bank.ApplyMonthlyInterest();
            _bank.UpdatePlans();
            Console.WriteLine("Monthly job executed!");
        }
    }
}
