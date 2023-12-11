namespace Jargar.BlackFinch.LoanApplication.Rules;

public class IsLoanToValueRatioAcceptableForCreditScore : ILoanApprovalRule
{
    public bool IsLoanApproved(LoanApplication loanApplication)
    {
        //If the value of the loan is £1 million or more then the LTV must be 60% or less and the credit score of the applicant must be 950 or more
        if (loanApplication.Amount >= 1000000)
        {
            return loanApplication is { LoanToValueRatio: <= 60, CreditScore: >= 950 };
        }
        //If the value of the loan is less than £1 million then the following rules apply:
        //If the LTV is less than 60%, the credit score of the applicant must be 750 or more
        //If the LTV is less than 80%, the credit score of the applicant must be 800 or more
        //If the LTV is less than 90%, the credit score of the applicant must be 900 or more
        //If the LTV is 90% or more, the application must be declined
        else
        {
            return loanApplication is
            { LoanToValueRatio: < 60, CreditScore: >= 750 } or
            { LoanToValueRatio: < 80, CreditScore: >= 800 } or
            { LoanToValueRatio: < 90, CreditScore: >= 900 };
        }
    }
}
