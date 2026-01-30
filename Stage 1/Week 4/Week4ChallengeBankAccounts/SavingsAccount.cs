using System;

namespace Week4ChallengeBankAccounts;

class SavingsAccount : Account
{
    // Set properties
	public decimal AnnualInterestRate { get; set; }

    // Default empty constructor
	public SavingsAccount() : base()
	{
		AnnualInterestRate = 0.00m;
	}

    // Constructor with parameters
	public SavingsAccount( int accountID, string accountType, decimal currentBalance, decimal annualInterestRate) : base(accountID, accountType, currentBalance)
	{
		AnnualInterestRate = annualInterestRate;
	}

    // Methods

    // Calculate interest earned using IAnnualAMountEarnedFromInterest interface method
    public double AnnualAmountEarnedFromInterest()
    {
        return (double)(CurrentBalance * AnnualInterestRate);
    }

    //Withdraw method for SavingsAccount. Account balance must be greater than the withdrawal amount.
    public override void Withdraw(decimal withdrawAmount)
    {
        if (withdrawAmount <= 0)
        {
            throw new ArgumentException("Error: Withdraw amount must be greater than 0.");
        }

        if (withdrawAmount < CurrentBalance)
        {
            CurrentBalance -= withdrawAmount;
        }
        else
        {
            throw new ArgumentException("Error: Withdraw amount exceeds or equals current balance.");
        }
    }

    // ToString method
    public override string ToString()
	{
		return base.ToString() + $" Annual interest rate: {AnnualInterestRate.ToString("P")} | Annual amount earned from interest: {AnnualAmountEarnedFromInterest().ToString("C")}";
	}

} // end of class



    //My broken attempt at a Withdraw method in the SavingsAccount class to review what went wrong

    // public override decimal Withdraw(int accountIDToWithdrawFrom, decimal withdrawAmount) //Acount balance must be greater than withdraw amount
    // {
    //     // Prompt user for account ID, confirm it exists, then withdraw money
    //     bool accountExists = false;
    //     int accountIDInput = 0;
    //     string withdrawResult = "";

    //     do
    //     {
    //         Console.Write("Enter account ID to withdraw money from: ");
    //         accountIDInput = int.Parse(Console.ReadLine());

    //         foreach(Account account in Program.accountList)
    //         {
    //             if (account.AccountID == accountIDInput)
    //             {
    //                 Console.WriteLine("Account Found.");
    //                 accountExists = true;
    //                 break;
    //             }
    //             Console.WriteLine("Account not found, please try again.");
    //             break;
    //         } // end of foreach loop
    //     }
    //     while (!accountExists); // end of do while loop

    //     do
    //     { 
    //         Console.Write($"Enter amount to withdraw from account {accountIDToWithdrawFrom}: ");
    //         decimal withdrawAmountInput = decimal.Parse(Console.ReadLine());

    //         if (withdrawAmountInput > 0)
    //         {
    //             foreach(Account account in Program.accountList)
    //             {
    //                 if (account.AccountID == accountIDInput)
    //                 {
    //                     account.CurrentBalance += depositAmountInput;
    //                     depositResult = $"Deposit of {depositAmountInput.ToString("C")} successful. New balance is {account.CurrentBalance.ToString("C")}";
    //                     Console.WriteLine(depositResult);
    //                     break;
    //                 }
    //             } // end of foreach loop
    //             inputGreaterThanZero = true;
    //         }
    //         else
    //         {
    //             Console.WriteLine("Error: Deposit amount must be greater than 0.");
    //         }
    //     }
	// 	while (!inputGreaterThanZero); // end of do while loop

	// 	    return depositResult;

    // } // end of Withdraw method