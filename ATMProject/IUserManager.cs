namespace ATMProject.Factories
{
	public interface IUserManager
	{
		void ApplyMonthlyInterestBonus(User user);
		User CreateUser(string name, decimal balance);
		void DepositMoney(User user, decimal amount);
		void UpdatePlan(User user);
		decimal ViewBalance(User user);
		void WithdrawMoney(User user, decimal amount);
	}
}