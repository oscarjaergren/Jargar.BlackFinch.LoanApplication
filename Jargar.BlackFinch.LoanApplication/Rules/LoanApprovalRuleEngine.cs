namespace Jargar.BlackFinch.LoanApplication.Rules;

public static class LoanApprovalRuleEngine
{
    private static readonly List<ILoanApprovalRule> rules;

    static LoanApprovalRuleEngine()
    {
        rules =
        [
            new IsLoanWithinBounds(),
            new IsLoanToValueRatioAcceptableForCreditScore()
        ];
    }

    public static LoanStatus Evaluate(LoanApplication loanApplication)
    {
        foreach (var rule in rules)
        {
            if (!rule.IsLoanApproved(loanApplication))
            {
                return LoanStatus.Declined;
            }
        }

        return LoanStatus.Approved;
    }
}