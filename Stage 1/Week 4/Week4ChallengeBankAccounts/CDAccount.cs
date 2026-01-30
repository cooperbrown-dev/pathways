using System;

namespace Week4ChallengeBankAccounts;

class CDAccount : Account
{
    // Set properties
	public decimal AnnualInterestRate { get; set; }
	public decimal PenaltyForEarlyWithdrawal { get; set; }

    // Default empty constructor
    public CDAccount() : base()
    {
        AnnualInterestRate = 0.00m;
        PenaltyForEarlyWithdrawal = 0.00m;
    }

    // Constructor with parameters
    public CDAccount(int accountID, string accountType, decimal currentBalance, decimal annualInterestRate, decimal penaltyForEarlyWithdrawal)
    : base(accountID, accountType, currentBalance)
    {
        AnnualInterestRate = annualInterestRate;
        PenaltyForEarlyWithdrawal = penaltyForEarlyWithdrawal;
    }

    // Methods

    // Withdraw method for CDAccount. Early withdrawal penalty is applied when withdrawing.
    public override void Withdraw(decimal withdrawAmount)
    {
        decimal currentPenalty = withdrawAmount * PenaltyForEarlyWithdrawal;
        if (withdrawAmount <= 0)
        {
            throw new ArgumentException("Error: Withdraw amount must be greater than 0.");
        }
        if (withdrawAmount <= CurrentBalance)
        {
            decimal totalWithdrawal = withdrawAmount + (withdrawAmount * PenaltyForEarlyWithdrawal);
            if (totalWithdrawal <= CurrentBalance)
            {
                CurrentBalance -= totalWithdrawal;
                Console.WriteLine($"{currentPenalty:C} penalty applied for early withdrawal.");
            }
            else
            {
                throw new ArgumentException($"Error: Withdraw amount plus penalty ({currentPenalty:C}) exceeds current balance.");
            }
        }
        else
        {
            throw new ArgumentException("Error: Withdraw amount must not exceed the available balance including any penalties.");
        }
    }

    // Calculate interest earned using polymorphism method from the IAnnualAMountEarnedFromInterest interface
    public double AnnualAmountEarnedFromInterest()
    {
        return (double)(CurrentBalance * AnnualInterestRate);
    }

    public override string ToString()
	{
		return base.ToString() + $" Annual interest rate: {AnnualInterestRate.ToString("P")} | Early withdrawal penalty: {PenaltyForEarlyWithdrawal.ToString("P")} | Annual amount earned from interest: {AnnualAmountEarnedFromInterest().ToString("C")}";
	}

} // end of class