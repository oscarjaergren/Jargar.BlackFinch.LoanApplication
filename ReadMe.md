# Lending Platform
Build a simple Console application using the technology of your choice (preferably C#) that enables the writing and reporting of loans as per the requirements below. 
This should be approached as a way that can demonstrate your process to solving problems (any required infrastructure can simply be mocked), and does not need to be built to a production standard. 
Instead, the exercise should be timeboxed to no longer than an hour.

Notes can be taken of any assumptions made, and also any other considerations or improvements that you might make if this was a production application.

## Requirements
**User inputs that the application should require:**
- Amount that the loan is for in GBP
- The value of the asset that the loan will be secured against
- The credit score of the applicant (between 1 and 999)

**Metrics that the application should output:**
- Whether or not the applicant was successful
- The total number of applicants to date, broken down by their success status
- The total value of loans written to date
- The mean average Loan to Value of all applications received to date

*Loan to Value (LTV) is the amount that the loan is for, expressed as a percentage of the value of the asset that the loan will be secured against.*

**Business rules used to derive whether or not the applicant was successful:**
- If the value of the loan is more than £1.5 million or less than £100,000 then the application must be declined
- If the value of the loan is £1 million or more then the LTV must be 60% or less and the credit score of the applicant must be 950 or more
- If the value of the loan is less than £1 million then the following rules apply:
  - If the LTV is less than 60%, the credit score of the applicant must be 750 or more
  - If the LTV is less than 80%, the credit score of the applicant must be 800 or more
  - If the LTV is less than 90%, the credit score of the applicant must be 900 or more
  - If the LTV is 90% or more, the application must be declined

Send through a public link to your GIT repository prior to interview.

--------------------------------------------

## Notes and Assumptions
The main assumption of this application has been that the purpose of this test is to be about how you go around
complicated business rules that can be extended or changed at any time. I've decided to before implementation started decided
go with the RuleEngine design pattern for handling business rules

I think therefore this is a good usecase for attempting to follow the SOLID practices as best as possible

Another assumption is that this is not testing if you ask about clearing up any requirements, combined with the strict time limit
and that I find the requirements to be more or less as clear as they can be.

---------
Another note is that you can see my use case of struct and NativeAot, which is just for the purpose of playing around with it in a production scenario. 

--Proper Git commit/history has been omitted due to the time constraints,
In production scenario this would be dealt with pull request and git squash merge

## Notes for self
Immutability when possible as it fits the premise of the application, each application is a new record.

Business Rules/intent should be documented in code, not the code itself

Tests will be skipped due to the time limit, but unit tests/integration tests would be really useful for this