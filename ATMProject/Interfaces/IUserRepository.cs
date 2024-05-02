using System.Collections.Generic;

namespace ATMProject.Factories
{
	public interface IUserRepository
	{
		IEnumerable<User> GetUsers { get; }

		void AddUser(User user);
		void RemoveUser(string name);
		User FindUserByName(string name);
		User FindUserById(string id);
	}
}