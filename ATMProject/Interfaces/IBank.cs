using System.Collections.Generic;

namespace ATMProject
{
	public interface IBank
	{
		void ApplyMonthlyInterest();
		(PlanType, int) CheckPlanType(string name);
		void CreateUser(string name, decimal balance);
		void DepositMoney(string name, decimal amount);
		IEnumerable<User> GetUsers();
		void RemoveUser(string name);
		decimal TransferMoney(string nameFrom, string nameTo, decimal amount);
		void UpdatePlans();
		decimal ViewBalance(string name);
		decimal WithdrawMoney(string name, decimal requestedAmount);
	}
}