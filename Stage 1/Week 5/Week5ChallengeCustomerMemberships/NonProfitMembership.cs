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
        decimal cashBack = 0.0m;
        if (IsItAMilitaryOrEducationalOrganization)
        {
            cashBack = (CashBackRate * 2) * CurrentMonthlyPurchases;
            Console.WriteLine($"Cash-back reward processed for Membership {MembershipID}: {cashBack:C} redeemed on {CurrentMonthlyPurchases:C} spent at a {(CashBackRate * 2):P} (double the rate for military or educational organizations). Current balance: $0.00.");

        }
        else
        {
            cashBack = CashBackRate * CurrentMonthlyPurchases;
            Console.WriteLine($"Cash-back reward processed for {MembershipType} Membership {MembershipID}: {cashBack:C} redeemed on {CurrentMonthlyPurchases:C} spent at a {CashBackRate:P} cash back rate. Current balance: $0.00.");

        }
        cashBack = 0.0m;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Cash Back Rate: {CashBackRate:P} | Military or Educational Organization?: {IsItAMilitaryOrEducationalOrganization}";
    }
}