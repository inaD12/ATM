using ATMProject.Factories;
using System.Collections.Generic;

namespace ATMProject
{
	public class Bank
	{
		private readonly IUserManager _userManager;

		private Bank(IUserManager userManager)
		{
			_userManager = userManager;
		}

		private static Bank _instance;
		private static readonly object _lock = new object();

		public static Bank GetInstance(IUserManager userManager)
		{
			if (_instance == null)
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new Bank(userManager);
					}
				}
			}
			return _instance;
		}

		private List<User> _users = new List<User>();

	}
}