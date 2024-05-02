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
				throw new System.ArgumentException("A user with this name already exists!");
			}

			Users.Add(user);
		}

		public void RemoveUser(string name)
		{
			User user = FindUserByName(name);

			if (user == null)
			{
				throw new System.ArgumentException("A user with this name doesn't exist!");
			}

			Users.Remove(user);
		}

		public User FindUserByName(string name)
		{
			return Users.FirstOrDefault(user => user.Name == name);
		}

		public User FindUserById(string id)
		{
			return Users.FirstOrDefault(user => user.UserId == id);
		}
	}
}
