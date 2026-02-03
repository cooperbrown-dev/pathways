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
        CurrentMonthlyPurchases -= cashBack; // Apply cash back by reducing current monthly purchases
    }

    public override string ToString()
    {
        return base.ToString() + $" | Cash Back Rate: {CashBackRate:P}";
    }
}