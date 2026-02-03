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
        CurrentMonthlyPurchases -= cashBack; // Apply cash back by reducing current monthly purchases
    }

    public decimal ApplySpecialOffer(decimal purchaseAmount)
    {
        return purchaseAmount * CashBackRate;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Cash Back Rate: {CashBackRate:P}";
    }
}