using ATMProject.Results;
using System.Collections.Generic;
using System.Linq;

namespace ATMProject.Commands
{
	internal class DisplayAllUsersCommand : ICommand
	{
		private readonly IBank _bank;

        public DisplayAllUsersCommand(IBank bank)
        {
            _bank = bank;
        }
        public Result Execute(List<string> parameters)
		{
			IEnumerable<User> users = _bank.GetUsers();

            if(users.Any())
            {
                return Result.Success($"All users in the system: {string.Join(", ", users.Select(user => user.Name))}");
            }
            else
            {
                return Result.Failure("No users in the system!");
            }
		}
	}
}
