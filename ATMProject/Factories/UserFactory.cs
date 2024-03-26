namespace ATMProject.Factories
{
	internal class UserFactory : IUserFactory
	{
		public User CreateStandardUser(int userId, string name, decimal balance)
		{
			return new User(userId, name, balance, PlanType.Standard);
		}

		public User CreatePremiumUser(int userId, string name, decimal balance)
		{
			return new User(userId, name, balance, PlanType.Premium);
		}

		public User CreatePlatinumUser(int userId, string name, decimal balance)
		{
			return new User(userId, name, balance, PlanType.Platinum);
		}
	}
}
