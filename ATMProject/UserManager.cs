namespace ATMProject.Factories
{
	internal class UserManager : IUserManager
	{
		private IUserFactory _userFactory;

		public UserManager(IUserFactory userFactory)
		{
			_userFactory = userFactory;
		}

		public User CreateUser(string name, decimal balance)
		{
			return _userFactory.CreateStandardUser(name, balance);
		}

		public void UpdatePlan(User user)
		{
			if (user.WithdrawsForThisMonth <= 10)
				user.Plan = PlanType.Standard;
			else if (user.WithdrawsForThisMonth <= 20)
				user.Plan = PlanType.Premium;
			else
				user.Plan = PlanType.Platinum;

			user.WithdrawsForThisMonth = 0;
		}

		public void ApplyMonthlyInterestBonus(User user)
		{
			decimal interest = user.Balance * 0.01m;
			user.Balance += interest;
		}

		public void WithdrawMoney(User user, decimal amount)
		{
			if(amount <= 0)
			{
				throw new System.ArgumentException("You can't withdraw an amount equal to or lower than zero!");
			}
			if (user.Balance - amount < 0)
			{
				throw new System.InvalidOperationException($"User '{user.Name}' only has a balance of {user.Balance}!");
			}

			user.Balance -= amount;
			user.WithdrawsForThisMonth++;
		}

		public void DepositMoney(User user, decimal amount)
		{
			if (amount <= 0)
			{
				throw new System.ArgumentException("You can't deposit an amount equal to or lower than zero!");
			}
			user.Balance += amount;
		}

		public decimal ViewBalance(User user)
		{
			return user.Balance;
		}
	}
}
