namespace ATMProject.TaxCalculators
{
	public class ThreePercentTaxPlan : IPercentTaxPlan
	{
		public decimal CalculateTax(decimal requestedAmount)
		{
			return requestedAmount * 0.03m;
		}
	}
}
