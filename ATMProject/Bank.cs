using ATMProject.Factories;

namespace ATMProject
{
	public class Bank
	{
		private readonly IUserManager _userManager;
		private readonly IUserRepository _userRepository;

		private Bank(IUserManager userManager, IUserRepository userRepository)
		{
			_userManager = userManager;
			_userRepository = userRepository;
		}

		private static Bank _instance;
		private static readonly object _lock = new object();

		public static Bank GetInstance(IUserManager userManager, IUserRepository userRepository)
		{
			if (_instance == null)
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new Bank(userManager, userRepository);
					}
				}
			}
			return _instance;
		}


	}
}