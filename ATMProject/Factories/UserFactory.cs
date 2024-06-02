namespace ATMProject.Factories
{
	internal class UserFactory : IUserFactory
	{
		public User CreateStandardUser(string name, decimal balance = 0)
		{
			return new User(name, balance, PlanType.Standard);
		}

		public User CreatePremiumUser(string name, decimal balance = 0)
		{
			return new User(name, balance, PlanType.Premium);
		}

		public User CreatePlatinumUser(string name, decimal balance = 0)
		{
			return new User(name, balance, PlanType.Platinum);
		}
	}
}
