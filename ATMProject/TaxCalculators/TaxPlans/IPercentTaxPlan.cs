namespace ATMProject
{
	public interface IPercentTaxPlan
	{
		decimal CalculateTax(decimal requestedAmount);
	}
}
