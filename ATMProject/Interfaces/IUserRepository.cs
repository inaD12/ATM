using ATMProject.Results;
using System.Collections.Generic;

namespace ATMProject.Factories
{
	public interface IUserRepository
	{
		IEnumerable<User> GetUsers { get; }

		Result AddUser(User user);
		Result RemoveUser(string name);
		Result FindUserByName(string name);
		Result FindUserById(string id);
	}
}