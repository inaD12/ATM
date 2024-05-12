namespace ATMProject.Factories
{
	internal interface IUserFactory
	{
		User CreatePlatinumUser(string name, decimal balance = 0);
		User CreatePremiumUser(string name, decimal balance = 0);
		User CreateStandardUser(string name, decimal balance = 0);
	}
}