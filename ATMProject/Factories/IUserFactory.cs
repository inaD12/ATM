namespace ATMProject.Factories
{
	internal interface IUserFactory
	{
		User CreatePlatinumUser(int userId, string name, decimal balance);
		User CreatePremiumUser(int userId, string name, decimal balance);
		User CreateStandardUser(int userId, string name, decimal balance);
	}
}