namespace ATMProject
{
	public interface IWithdrawalTaxManager
	{
		decimal CalculateTax(decimal requestedAmount);
	}
}