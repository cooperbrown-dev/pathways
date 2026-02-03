namespace Week5ChallengeCustomerMemberships;
public class NonProfitMembership : Membership
{
    public decimal CashBackRate { get; } = 0.03m; // 3% cash back rate

    public bool IsItAMilitaryOrEducationalOrganization { get; set; }

    public NonProfitMembership() : base()
    {
        MembershipType = "NonProfit";
        AnnualCost = 0M;
        IsItAMilitaryOrEducationalOrganization = false;
    }
    public NonProfitMembership(int membershipID, string contactEmail, decimal currentMonthlyPurchases, bool isItAMilitaryOrEducationalOrganization)
        : base(membershipID, contactEmail, "NonProfit", 0M, currentMonthlyPurchases)
    {
        IsItAMilitaryOrEducationalOrganization = isItAMilitaryOrEducationalOrganization;
    }

    public override void ApplyCashBackRewards()
    {
        decimal cashBack = CurrentMonthlyPurchases * CashBackRate;
        CurrentMonthlyPurchases -= cashBack; // Apply cash back by reducing current monthly purchases
    }

    public override string ToString()
    {
        return base.ToString() + $" | Cash Back Rate: {CashBackRate:P} | Military or Educational Organization ?: {IsItAMilitaryOrEducationalOrganization}";
    }
}