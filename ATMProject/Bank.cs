using ATMProject.Factories;
using System.Collections.Generic;

namespace ATMProject
{
	public class Bank
	{
		private readonly IUserManager _userManager;
		private readonly IUserRepository _userRepository;
		private readonly IWithdrawalTaxManager _withdrawalTaxManager;

		public Bank(IUserManager userManager, IUserRepository userRepository, IWithdrawalTaxManager withdrawalTaxManager)
		{
			_userManager = userManager;
			_userRepository = userRepository;
			_withdrawalTaxManager = withdrawalTaxManager;
		}

		//private static Bank _instance;
		//private static readonly object _lock = new object();

		//public static Bank GetInstance(IUserManager userManager, IUserRepository userRepository)
		//{
		//	if (_instance == null)
		//	{
		//		lock (_lock)
		//		{
		//			if (_instance == null)
		//			{
		//				_instance = new Bank(userManager, userRepository);
		//			}
		//		}
		//	}
		//	return _instance;
		//}

		public void CreateUser(string name, decimal balance)
		{
			_userRepository.AddUser(_userManager.CreateUser(name, balance));
		}

		public IEnumerable<User> GetUsers()
		{
			return _userRepository.GetUsers;
		}

		public void RemoveUser(string name)
		{
			_userRepository.RemoveUser(name);
		}

		public decimal WithdrawMoney(string name, decimal requestedAmount)
		{
			User user = GetUserByName(name);

			decimal tax = _withdrawalTaxManager.CalculateTax(requestedAmount);

			_userManager.WithdrawMoney(user, requestedAmount + tax);

			return tax;
		}

		public decimal ViewBalance(string name)
		{
			User user = GetUserByName(name);

			return _userManager.ViewBalance(user);
		}

		public void DepositMoney(string name, decimal amount)
		{
			User user = GetUserByName(name);

			_userManager.DepositMoney(user, amount);
		}

		public decimal TransferMoney(string nameFrom, string nameTo, decimal amount)
		{
			decimal tax = WithdrawMoney(nameFrom, amount);
			DepositMoney(nameFrom, amount);

			return tax;
		}

		public (PlanType,int) CheckPlanType(string name)
		{
			User user = GetUserByName(name);

			return (user.Plan, user.WithdrawsForThisMonth);
		}

		private User GetUserByName(string name)
		{
			return _userRepository.FindUserByName(name);
		}
	}
}