namespace Jargar.BlackFinch.LoanApplication.Rules;

// If the value of the loan is more than £1.5 million or less than £100,000 then the application must be declined
public class IsLoanWithinBounds : ILoanApprovalRule
{
    //The min and maxvalue should in prod scenario be constants in this class outside the function
    public bool IsLoanApproved(LoanApplication loanApplication)
    {
        return loanApplication.Amount is >= 100000 and <= 1500000;
    }
}