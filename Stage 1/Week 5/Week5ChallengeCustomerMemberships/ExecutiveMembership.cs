namespace Week5ChallengeCustomerMemberships;
public class ExecutiveMembership : Membership, ISpecialOffer
{
    public decimal Below1000DollarsSpentCashBackRate { get; } = 0.05m; // 5% cash back rate for purchases below $1000
    public decimal Above1000DollarsSpentCashBackRate { get; } = 0.02m; // 2% cash back rate for purchases above $1000

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
        decimal over1000CashBack = 0.0m;

        if (CurrentMonthlyPurchases < 1000.0m)
        {
            under1000CashBack = CurrentMonthlyPurchases * Below1000DollarsSpentCashBackRate;
            Console.WriteLine($"Cash-back reward processed for {MembershipType} Membership {MembershipID}: {under1000CashBack:C} redeemed on {CurrentMonthlyPurchases:C} spent at a {Below1000DollarsSpentCashBackRate:P} cash back rate. Current balance: $0.00.");
        }

        if (CurrentMonthlyPurchases >= 1000.0m)
        {
            over1000CashBack = (999.99m * Below1000DollarsSpentCashBackRate) + ((CurrentMonthlyPurchases - 999.99m) * Above1000DollarsSpentCashBackRate);
            Console.WriteLine($"Cash-back reward processed for {MembershipType} Membership {MembershipID}: {over1000CashBack:C} redeemed on {CurrentMonthlyPurchases:C} spent at a {Below1000DollarsSpentCashBackRate:P} under cash back rate for purchases under $1000 and {Above1000DollarsSpentCashBackRate:P} cash back rate for purchases over $1000. Current balance: $0.00.");
        }

        under1000CashBack = 0.0m;
        over1000CashBack = 0.0m;
    }

    public string SpecialOffer(decimal AnnualCost)
    {
        return (AnnualCost * 0.50m).ToString("C");
    }

    public override string ToString()
    {
        return base.ToString() + $" | Below $1000 Spent Cash Back Rate: {Below1000DollarsSpentCashBackRate:P} | Above $1000 Spent Cash Back Rate: {Above1000DollarsSpentCashBackRate:P} | Special Offer Available: {SpecialOffer(AnnualCost).ToString()} for an annual {MembershipType} membership. 50% off!";
    }
}