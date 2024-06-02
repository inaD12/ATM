using ATMProject.Results;

namespace ATMProject.Factories
{
	public interface IUserManager
	{
		void ApplyMonthlyInterestBonus(User user);
		User CreateUser(string name, decimal balance);
		Result DepositMoney(User user, decimal amount);
		void UpdatePlan(User user);
		decimal ViewBalance(User user);
		Result WithdrawMoney(User user, decimal amount);
	}
}