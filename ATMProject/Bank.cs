using ATMProject.Factories;
using ATMProject.Results;
using System.Collections.Generic;

namespace ATMProject
{
	public class Bank : IBank
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

		public Result WithdrawMoney(string name, decimal requestedAmount)
		{
			Result res = GetUserByName(name);

			if (res.IsFailure)
			{
				return res;
			}

			decimal tax = _withdrawalTaxManager.CalculateTax(requestedAmount);

			Result managerRes = _userManager.WithdrawMoney((User)res.Object, requestedAmount + tax);

			if (managerRes.IsFailure)
			{
				return managerRes;
			}

			return Result.Success(obj: tax);
		}

		public Result ViewBalance(string name)
		{
			Result res = GetUserByName(name);

			if (res.IsFailure)
			{
				return res;
			}

			decimal balance = _userManager.ViewBalance((User)res.Object);

			return Result.Success(obj: balance);
		}

		public Result DepositMoney(string name, decimal amount)
		{
			Result res = GetUserByName(name);

			if (res.IsFailure)
			{
				return res;
			}

			return _userManager.DepositMoney((User)res.Object, amount);
		}

		public Result TransferMoney(string nameFrom, string nameTo, decimal amount)
		{
			Result withdrawRes = WithdrawMoney(nameFrom, amount);

			if (withdrawRes.IsFailure) 
			{
				return withdrawRes;
			}

			Result depositRes = DepositMoney(nameTo, amount);

			if (depositRes.IsFailure)
			{
				return depositRes;
			}

			return withdrawRes;
		}

		public Result CheckPlanType(string name)
		{
			Result res = GetUserByName(name);

			if (res.IsFailure)
			{
				return res;
			}

			User user = (User)res.Object;

			return Result.Success(obj:(user.Plan, user.WithdrawsForThisMonth));
		}

		public void ApplyMonthlyInterest()
		{
			UserAction action = _userManager.ApplyMonthlyInterestBonus;

			DoSomethingToAllUsers(action);
		}

		public void UpdatePlans()
		{
			UserAction action = _userManager.UpdatePlan;

			DoSomethingToAllUsers(action);
		}

		private Result GetUserByName(string name)
		{
			return _userRepository.FindUserByName(name);
		}

		private void DoSomethingToAllUsers(UserAction action)
		{
			IEnumerable<User> users = _userRepository.GetUsers;

			foreach (User user in users)
			{
				if (action != null)
				{
					action(user);
				}
			}
		}

		private delegate void UserAction(User user);
	}
} 