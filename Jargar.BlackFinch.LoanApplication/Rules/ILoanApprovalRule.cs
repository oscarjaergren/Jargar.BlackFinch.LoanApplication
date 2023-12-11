namespace Jargar.BlackFinch.LoanApplication.Rules;
public interface ILoanApprovalRule
{
    bool IsLoanApproved(LoanApplication loanApplication);
}