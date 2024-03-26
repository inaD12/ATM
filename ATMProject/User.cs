using System;

namespace ATMProject
{
	class User
	{
		public string UserId { get; set; }
		public string Name { get; set; }
		public decimal Balance { get; set; }
		public int WithdrawsForThisMonth { get; set; }
		public PlanType Plan { get; set; }

		public User(string name, decimal balance, PlanType plan = PlanType.Standard)
		{
			UserId = Guid.NewGuid().ToString();
			Name = name;
			Balance = balance;
			Plan = plan;
		}
	}

	enum PlanType
	{
		Standard,
		Premium,
		Platinum
	}
}
