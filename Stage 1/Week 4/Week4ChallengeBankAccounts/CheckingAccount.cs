using System;

namespace Week4ChallengeBankAccounts;

class CheckingAccount : Account
{
    // Set properties
	public decimal AnnualFee { get; set; }

    // Default empty constructor
	public CheckingAccount() : base()
	{
		AnnualFee = 0.00m;
	}

    // Constructor with parameters
	public CheckingAccount(int accountID, string accountType, decimal currentBalance, decimal annualFee) : base(accountID, accountType, currentBalance)
	{
		AnnualFee = annualFee;
	}

    // Methods

    //Withdraw method for CheckingAccount - A checking account withdrawal is allowed but only up to 50% of the account balance.
    public override void Withdraw(decimal withdrawAmount)
    {
        if (withdrawAmount <= 0)
        {
            throw new ArgumentException("Error: Withdraw amount must be greater than 0.");
        }

        if (withdrawAmount <= (CurrentBalance * 0.5m))
        {
            CurrentBalance -= withdrawAmount;
        }
        else
        {
            throw new ArgumentException("Error: Withdraw amount exceeds 50% of current balance.");
        }
    }

    public override string ToString()
	{
		return base.ToString() + $" Annual fee: {AnnualFee.ToString("C")}";
	}
} // end of class