namespace ATMProject
{
	public interface ITaxCalculator
	{
		decimal CalculateTax(decimal requestedAmount);
		void SetTaxPlan(IPercentTaxPlan tax);
	}
}