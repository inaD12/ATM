using System;

namespace ATMProject.Jobs
{
	internal class MonthlyInterestJob
	{
        private readonly Bank _bank;
        public MonthlyInterestJob(Bank bank)
        {
            _bank = bank;
        }

        public void Execute()
        {
            Console.WriteLine("Monthly interest job executed!");
            _bank.ApplyMonthlyInterest();
        }
    }
}
