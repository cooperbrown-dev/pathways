namespace Week5ChallengeCustomerMemberships;
public class RegularMembership : Membership, ISpecialOffer
{
    public decimal CashBackRate { get; } = 0.01m; // 1% cash back rate

    public RegularMembership() : base()
    {
        MembershipType = "Regular";
        AnnualCost = 65.00M;
    }

    public RegularMembership(int membershipID, string contactEmail, decimal currentMonthlyPurchases)
        : base(membershipID, contactEmail, "Regular", 65.00M, currentMonthlyPurchases)
    {
    }

    public override void ApplyCashBackRewards()
    {
        decimal cashBack = CurrentMonthlyPurchases * CashBackRate;
        Console.WriteLine($"Cash-back reward processed for {MembershipType} Membership {MembershipID}: {cashBack:C} redeemed on {CurrentMonthlyPurchases:C} spent at a {CashBackRate:P} cash back rate. Current balance: $0.00.");
        cashBack = 0.0m;
    }

    public string SpecialOffer(decimal AnnualCost)
    {
        decimal result = AnnualCost * 0.25m;
        return result.ToString("C");
    }

    public override string ToString()
    {
        return base.ToString() + $" | Cash Back Rate: {CashBackRate:P} | Special offer available: {SpecialOffer(AnnualCost).ToString()} for an annual {MembershipType} membership. 75% off!";
    }
}