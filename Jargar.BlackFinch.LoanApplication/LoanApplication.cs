using Jargar.BlackFinch.LoanApplication.Rules;

namespace Jargar.BlackFinch.LoanApplication;

// In a production scenario this probably shouldn't be a struct as I can see an actual enterprise application
// would grow a lot more complex but for this simplified scenario it works quite well for perfomance reasons
public readonly record struct LoanApplication
{
    public decimal Amount { get; init; }

    public decimal AssetValue { get; init; }

    public int CreditScore { get; init; }

    public decimal LoanToValueRatio { get; init; }

    public LoanStatus Status { get; init; }

    //Trival logic such as Amount cannot be less than 0 e.t.c should be added here in a prod scenario 
    //Because you cannot apply for negative loan
    public LoanApplication(decimal amount, decimal assetValue, int creditScore)
    {
        Amount = amount;
        AssetValue = assetValue;
        CreditScore = creditScore;
        LoanToValueRatio = Amount / AssetValue;
        Status = LoanApprovalRuleEngine.Evaluate(this);
    }
}