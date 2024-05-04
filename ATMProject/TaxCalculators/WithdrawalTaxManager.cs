using ATMProject.Factories;

namespace ATMProject
{
	public class WithdrawalTaxManager : IWithdrawalTaxManager
	{
		private ITaxCalculator _taxCalculator;
		private readonly ITaxPlanFactory _taxPlanFactory;

		public WithdrawalTaxManager(ITaxCalculator taxCalculator, ITaxPlanFactory taxPlanFactory)
		{
			_taxCalculator = taxCalculator;
			_taxPlanFactory = taxPlanFactory;
		}

		public decimal CalculateTax(decimal requestedAmount)
		{
			ManageTaxPlan(requestedAmount);

			return _taxCalculator.CalculateTax(requestedAmount);
		}

		private void ManageTaxPlan(decimal requestedAmount)
		{
			if (requestedAmount < 100)
			{
				_taxCalculator.SetTaxPlan(_taxPlanFactory.CreateThreePercentTaxPlan());
			}
			else if (requestedAmount < 1000)
			{
				_taxCalculator.SetTaxPlan(_taxPlanFactory.CreateFivePercentTaxPlan());
			}
			else
			{
				_taxCalculator.SetTaxPlan(_taxPlanFactory.CreateTenPercentTaxPlan());
			}
		}
	}
}
