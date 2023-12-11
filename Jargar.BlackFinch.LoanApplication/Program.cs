using Jargar.BlackFinch.LoanApplication;

List<LoanApplication> loanApplications = [];

do
{
    GetLoanDetailsFromUser(loanApplications);

    OutputMetrics();

    Console.WriteLine("Do you want to process another loan? (yes/no)");
}
while (Console.ReadLine().Equals("yes", StringComparison.CurrentCultureIgnoreCase));

//#Business rules
//Metrics that the application should output:
//Whether or not the applicant was successful
//The total number of applicants to date, broken down by their success status
//The total value of loans written to date
//The mean average Loan to Value of all applications received to date
void OutputMetrics()
{
    // Metrics
    int totalApplicants = loanApplications.Count;
    int successfulApplicants = loanApplications.Count(app => app.Status == LoanStatus.Approved);
    int declinedApplicants = loanApplications.Count(app => app.Status == LoanStatus.Declined);
    decimal totalLoans = loanApplications.Where(app => app.Status == LoanStatus.Approved).Sum(app => app.Amount);
    decimal meanLTV = loanApplications.Average(app => app.LoanToValueRatio);

    // Output metrics
    Console.WriteLine($"Total Applicants: {totalApplicants}");
    Console.WriteLine($"Successful Applicants: {successfulApplicants}");
    Console.WriteLine($"Declined Applicants: {declinedApplicants}");
    Console.WriteLine($"Total Loans: £{totalLoans:N2}");
    Console.WriteLine($"Mean Loan to Value: {meanLTV:P}");
}

//#Self Reflection
//1:
//The Console.ReadLine and parsing can be refactored out to reduce code duplication
//Maybe good usecase for generics?

//2:
//The parsing should be wrapped in try/catching and have error messages if parsing fails

//#Business rules
//User inputs that the application should require:
//Amount that the loan is for in GBP
//The value of the asset that the loan will be secured against
//The credit score of the applicant (between 1 and 999)
static void GetLoanDetailsFromUser(List<LoanApplication> loanApplications)
{
    Console.WriteLine("Enter loan details:");
    Console.Write("Amount in GBP: ");
    decimal loanAmount = decimal.Parse(Console.ReadLine());

    Console.Write("Asset value: ");
    decimal assetValue = decimal.Parse(Console.ReadLine());

    Console.Write("Credit score (1-999): ");
    int creditScore = int.Parse(Console.ReadLine());

    var loanApplication = new LoanApplication(loanAmount, assetValue, creditScore);
    loanApplications.Add(loanApplication);
}