using System;

namespace Week4ChallengeBankAccounts;

abstract class Account
{
    // Set properties
	public int AccountID { get; set; }
	public string AccountType { get; set; }
	public decimal CurrentBalance {get; set;}

    // Default empty constructor
    public Account()
	{
		AccountID = 0;
		AccountType = "";
		CurrentBalance = 0.00m;
	} 

    //Defaust constructor with parameters
	public Account(int accountID, string accountType, decimal currentBalance) //constructor with parameters
	{
		AccountID = accountID;
		AccountType = accountType;
		CurrentBalance = currentBalance;
	}

    // Methods

    // Deposit method for all accounts. Deposit amount must be greater than 0.
    public void Deposit(decimal depositAmount)
	    {
            if (depositAmount <= 0)
            {
                throw new ArgumentException("Error: Deposit amount must be greater than 0.");
            }

            CurrentBalance += depositAmount; //add the deposit amount to the current balance

	    } // end of Deposit method

    // Abstract Withdraw method to be overridden in derived classes
    public abstract void Withdraw(decimal withdrawAmount);

    // ToString method
    public override string ToString()
	{
		return $"Account ID: {AccountID} | Account type: {AccountType} | Current balance: {CurrentBalance.ToString("C")}.";
	}


} // end of class