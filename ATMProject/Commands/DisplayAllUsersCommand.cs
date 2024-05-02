using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMProject.Commands
{
	internal class DisplayAllUsersCommand : ICommand
	{
		private readonly Bank _bank;

        public DisplayAllUsersCommand(Bank bank)
        {
            _bank = bank;
        }
        public void Execute(List<string> parameters)
		{
			IEnumerable<User> users = _bank.GetUsers();

            if(users.Any())
            {
            Console.WriteLine($"All users in the system: {string.Join(", ", users.Select(user => user.Name))}");
            }
            else
            {
                Console.WriteLine("No users in the system!");
            }
        }
	}
}
