namespace ATMProject
{
	class User
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public decimal Balance { get; set; }
		public PlanType Plan { get; set; }

		public User(int userId, string name, decimal balance, PlanType plan = PlanType.Standard)
		{
			UserId = userId;
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
