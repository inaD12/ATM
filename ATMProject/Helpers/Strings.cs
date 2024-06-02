using System;

namespace ATMProject
{
	public static class Strings
	{
		public const string AllCommands =
@"Commands:
CreateUser {username} {wallet balance} - Creates a user
DeleteUser {username} - Deletes a user
DisplayAllUsers - Displays the usernames of all users in the system
Deposit {username} {amount to add to wallet balance} - Deposits money to a user's wallet
Withdraw {username} {amount to withdraw from wallet} - Withdraws money from a user's wallet (taxed according to the amount)
ViewBalance {username} - Displays a user's wallet balance
Transfer {username of transferer} {username of receiver} {amount to transfer} - Transfers money from a user's wallet to another user's wallet (taxed according to the amount)
CheckPlan {username} - Displays the current plan of the user
End - Stops the program.
";
		public const string InvalidParams = "Invalid parameters!";
	}
}
