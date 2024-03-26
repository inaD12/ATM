namespace ATMProject.Factories
{
	internal interface IUserFactory
	{
		User CreatePlatinumUser(string name, decimal balance);
		User CreatePremiumUser(string name, decimal balance);
		User CreateStandardUser(string name, decimal balance);
	}
}