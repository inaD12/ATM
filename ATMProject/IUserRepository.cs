using System.Collections.Generic;

namespace ATMProject.Factories
{
	public interface IUserRepository
	{
		IEnumerable<User> GetUsers { get; }

		void AddUser(User user);
		void RenoveUser(User user);
		User FindUserByName(string name);
		User FindById(string id);
	}
}