using ATMProject.Results;
using System.Collections.Generic;
using System.Linq;

namespace ATMProject.Factories
{
	public class UserRepository : IUserRepository
	{
		private List<User> Users = new List<User>();

		public IEnumerable<User> GetUsers { get { return Users; } }

		public Result AddUser(User user)
		{
			if (Users.Any(usr => usr.Name == user.Name))
			{
				return Result.Failure($"A user with the name '{user.Name}' already exists!");
			}

			Users.Add(user);

			return Result.Success();
		}

		public Result RemoveUser(string name)
		{
			Result res = FindUserByName(name);

			if (res.IsFailure)
			{
				return res;
			}

			Users.Remove((User)res.Object);

			return Result.Success();
		}

		public Result FindUserByName(string name)
		{
			User user = Users.FirstOrDefault(usr => usr.Name == name);

			if (user == null)
			{
				return Result.Failure($"A user with the name '{name}' doesn't exist!");
			}

			return Result.Success(obj: user);
		}

		public Result FindUserById(string id)
		{
			User user = Users.FirstOrDefault(usr => usr.UserId == id);

			if (user == null)
			{
				return Result.Failure($"A user with the id '{id}' doesn't exist!");
			}

			return Result.Success(obj: user);
		}
	}
}
