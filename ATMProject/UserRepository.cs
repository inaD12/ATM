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
			if (!Users.Contains(user))
			{
				Users.Add(user);
			}
		}

		public void RenoveUser(User user)
		{
			Users.Remove(user);
		}

		public User FindUserByName(string name)
		{
			return Users.FirstOrDefault(user => user.Name == name);
		}

		public User FindById(string id)
		{
			return Users.FirstOrDefault(user => user.UserId == id);
		}
	}
}
