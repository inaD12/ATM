namespace ATMProject.Factories
{
	internal class UserManager
	{
		private IUserFactory _userFactory;

		public UserManager(IUserFactory userFactory)
		{
			_userFactory = userFactory;
		}

		public void AddUser(string name, decimal balance)
		{
			User user = _userFactory.CreateStandardUser(name, balance);
		}

		public void UpdatePlan(User user)
		{
			if (user.WithdrawsForThisMonth <= 10)
				user.Plan = PlanType.Standard;
			else if (user.WithdrawsForThisMonth <= 20)
				user.Plan = PlanType.Premium;
			else
				user.Plan = PlanType.Platinum;
		}

		public void ApplyMonthlyInterestBonus(User user)
		{
				decimal interest = user.Balance * 0.01m;
				user.Balance += interest;
		}
	}
}
