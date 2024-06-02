namespace ATMProject.Factories
{
	public interface ITaxPlanFactory
	{
		IPercentTaxPlan CreateFivePercentTaxPlan();
		IPercentTaxPlan CreateTenPercentTaxPlan();
		IPercentTaxPlan CreateThreePercentTaxPlan();
	}
}