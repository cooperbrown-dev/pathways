namespace Week4ChallengeBankAccounts;

public enum AccountType
{
	None,
	Checking,
	Savings,
	CD
}

public abstract class Account
{
	public int AccountID { get; set; } = 0;
	public AccountType AccountType { get; set; } = AccountType.None;
	public decimal CurrentBalance {get; set;} = 0.00m;

    // Deposit method for all accounts. Deposit amount must be greater than 0.
    public virtual void Deposit(decimal depositAmount)
	{
		if (depositAmount <= 0)
		{
			throw new ArgumentException("Error: Deposit amount must be greater than 0.");
		}

		CurrentBalance += depositAmount; //add the deposit amount to the current balance
	}

    // Abstract Withdraw method to be overridden in derived classes
    public abstract void Withdraw(decimal withdrawAmount);

    // ToString method
    public override string ToString()
	{
		return $"Account ID: {AccountID} | Account type: {AccountType} | Current balance: {CurrentBalance.ToString("C")}.";
	}

}