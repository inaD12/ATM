using ATMProject.Factories;
using System.Collections.Generic;

namespace ATMProject
{
	public class Bank
	{
		private readonly IUserManager _userManager;
		private readonly IUserRepository _userRepository;

		public Bank(IUserManager userManager, IUserRepository userRepository)
		{
			_userManager = userManager;
			_userRepository = userRepository;
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

		public void WithdrawMoney(string name, decimal amount)
		{
			User user = GetUserByName(name);

			_userManager.WithdrawMoney(user, amount);
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

		public void TransferMoney(string nameFrom, string nameTo, decimal amount)
		{
			User userFrom = GetUserByName(nameFrom);
			User userTo = GetUserByName(nameTo);

			_userManager.WithdrawMoney(userFrom, amount);
			_userManager.DepositMoney(userTo, amount);
		}

		private User GetUserByName(string name)
		{
			return _userRepository.FindUserByName(name);
		}
	}
}