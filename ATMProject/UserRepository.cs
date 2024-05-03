using System.Collections.Generic;
using System.Linq;

namespace ATMProject.Factories
{
	public class UserRepository : IUserRepository
	{
		private List<User> Users = new List<User>();

		public IEnumerable<User> GetUsers { get { return Users; } }

		public void AddUser(User user)
		{
			if (Users.Any(usr => usr.Name == user.Name))
			{
				throw new System.ArgumentException($"A user with the name '{user.Name}' already exists!");
			}

			Users.Add(user);
		}

		public void RemoveUser(string name)
		{
			User user = FindUserByName(name);

			Users.Remove(user);
		}

		public User FindUserByName(string name)
		{
			User user = Users.FirstOrDefault(usr => usr.Name == name);

			if (user == null)
			{
				throw new System.ArgumentException($"A user with the name '{name}' doesn't exist!");
			}

			return user;
		}

		public User FindUserById(string id)
		{
			User user = Users.FirstOrDefault(usr => usr.UserId == id);

			if (user == null)
			{
				throw new System.ArgumentException($"A user with the id '{id}' doesn't exist!");
			}

			return user;
		}
	}
}
