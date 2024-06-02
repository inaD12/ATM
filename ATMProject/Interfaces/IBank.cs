using ATMProject.Results;
using System.Collections.Generic;

namespace ATMProject
{
	public interface IBank
	{
		void ApplyMonthlyInterest();
		Result CheckPlanType(string name);
		void CreateUser(string name, decimal balance);
		Result DepositMoney(string name, decimal amount);
		IEnumerable<User> GetUsers();
		void RemoveUser(string name);
		Result TransferMoney(string nameFrom, string nameTo, decimal amount);
		void UpdatePlans();
		Result ViewBalance(string name);
		Result WithdrawMoney(string name, decimal requestedAmount);
	}
}