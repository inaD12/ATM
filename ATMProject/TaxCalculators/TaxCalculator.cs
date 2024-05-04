namespace ATMProject
{
	public class TaxCalculator : ITaxCalculator
	{
		private IPercentTaxPlan percentTax;

		public void SetTaxPlan(IPercentTaxPlan tax)
		{
			percentTax = tax;
		}

		public decimal CalculateTax(decimal requestedAmount)
		{
			return percentTax.CalculateTax(requestedAmount);
		}
	}
}
