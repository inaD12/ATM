namespace ATMProject.TaxCalculators
{
	internal class TenPercentTaxPlan : IPercentTaxPlan
	{
		public decimal CalculateTax(decimal requestedAmount)
		{
			return requestedAmount * 0.10m;
		}
	}
}
