namespace ATMProject.TaxCalculators
{
	internal class FivePercentTaxPlan : IPercentTaxPlan
	{
		public decimal CalculateTax(decimal requestedAmount)
		{
			return requestedAmount * 0.05m;
		}
	}
}
