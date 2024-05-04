using ATMProject.TaxCalculators;

namespace ATMProject.Factories
{
	public class TaxPlanFactory : ITaxPlanFactory
	{
		public IPercentTaxPlan CreateThreePercentTaxPlan()
		{
			return new ThreePercentTaxPlan();
		}

		public IPercentTaxPlan CreateFivePercentTaxPlan()
		{
			return new FivePercentTaxPlan();
		}

		public IPercentTaxPlan CreateTenPercentTaxPlan()
		{
			return new TenPercentTaxPlan();
		}
	}
}
