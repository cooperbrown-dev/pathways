namespace Week5ChallengeCustomerMemberships;
public class ExecutiveMembership : Membership, ISpecialOffer
{
    public decimal Below1000DollarsSpentCashBackRate { get; } = 0.02m; // 2% cash back rate for purchases below $1000
    public decimal Above1000DollarsSpentCashBackRate { get; } = 0.05m; // 5% cash back rate for purchases above $1000

    public ExecutiveMembership() : base()
    {
        MembershipType = "Executive";
        AnnualCost = 130.00M;
    }   

    public ExecutiveMembership(int membershipID, string contactEmail, decimal currentMonthlyPurchases)
        : base(membershipID, contactEmail, "Executive", 130.00M, currentMonthlyPurchases)
    {
    }

    public override void ApplyCashBackRewards()
    {
        decimal under1000CashBack = 0.0m;

        if (CurrentMonthlyPurchases < 1000.0m)
        {
            under1000CashBack = CurrentMonthlyPurchases * Below1000DollarsSpentCashBackRate;
        }
        decimal over1000CashBack = 0.0m;

        if (CurrentMonthlyPurchases >= 1000.0m)
        {
            over1000CashBack = (CurrentMonthlyPurchases - 1000.0m) * Above1000DollarsSpentCashBackRate;
        }
        decimal totalCashBack = under1000CashBack + over1000CashBack;

        Console.WriteLine($"Cash-back reward request for membership {MembershipID} in the amount of {totalCashBack:C} has been made.");

        totalCashBack = 0.0m;
    }

    public decimal ApplySpecialOffer(decimal purchaseAmount)
    {
        if (purchaseAmount < 1000.0m)
        {
            return purchaseAmount * Below1000DollarsSpentCashBackRate;
        }
        else
        {
            return purchaseAmount * Above1000DollarsSpentCashBackRate;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $" | Below $1000 Spent Cash Back Rate: {Below1000DollarsSpentCashBackRate:P} | Above $1000 Spent Cash Back Rate: {Above1000DollarsSpentCashBackRate:P}";
    }
}