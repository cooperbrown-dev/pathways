namespace Week5ChallengeCustomerMemberships;

public abstract class Membership
{
    public int MembershipID { get; set; }
    public string ContactEmail { get; set; }
    public string MembershipType { get; set; }
    public decimal AnnualCost { get; set; }
    public decimal CurrentMonthlyPurchases { get; set; }

    public Membership()
    {
        MembershipID = 0;
        ContactEmail = string.Empty;
        MembershipType = string.Empty;
        AnnualCost = 0.0m;
        CurrentMonthlyPurchases = 0.0m;
    }

    public Membership(int membershipID, string contactEmail, string membershipType, decimal annualCost, decimal currentMonthlyPurchases)
    {
        MembershipID = membershipID;
        ContactEmail = contactEmail;
        MembershipType = membershipType;
        AnnualCost = annualCost;
        CurrentMonthlyPurchases = currentMonthlyPurchases;
    }

    public void Purchase(decimal amount)
    {
        CurrentMonthlyPurchases += amount;
    }

    public void Return(decimal amount)
    {
        CurrentMonthlyPurchases -= amount;
    }

    public abstract void ApplyCashBackRewards();

    public override string ToString()
    {
        return $"Membership ID: {MembershipID} | Membership Type: {MembershipType} | Contact Email: {ContactEmail} | Annual Cost: {AnnualCost:C} | Current Monthly Purchases: {CurrentMonthlyPurchases:C}";
    }
}