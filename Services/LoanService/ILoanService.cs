using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.Services.LoanService
{
    public interface ILoanService
    {
        Loan RequestLoan(int accountId, decimal amount, decimal interestRate, int durationMonths);
        List<Loan> GetAccountLoans(int accountId);
    }
}
