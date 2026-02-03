namespace Week5ChallengeCustomerMemberships;
public class CorporateMembership : Membership
{
    public decimal CashBackRate { get; set; } = 0.04m; // 4% cash back rate

    public CorporateMembership() : base()
    {
        MembershipType = "Corporate";
        AnnualCost = 1000.00M;
    }

    public CorporateMembership(int membershipID, string contactEmail, decimal currentMonthlyPurchases)
        : base(membershipID, contactEmail, "Corporate", 1000.00M, currentMonthlyPurchases)
    {
    }

    public override void ApplyCashBackRewards()
    {
        decimal cashBack = CurrentMonthlyPurchases * CashBackRate; 
        Console.WriteLine($"Cash-back reward processed for {MembershipType} Membership {MembershipID}: {cashBack:C} redeemed on {CurrentMonthlyPurchases:C} spent at a {CashBackRate:P} cash back rate. Current balance: $0.00.");
        cashBack = 0.0m;

    }

    public override string ToString()
    {
        return base.ToString() + $" | Cash Back Rate: {CashBackRate:P}";
    }
}