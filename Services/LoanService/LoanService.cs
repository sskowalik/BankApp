using System;
using System.Collections.Generic;
using System.Linq;
using BankApp.Models;
using BankApp.Services.AccountService;

namespace BankApp.Services.LoanService
{
    public class LoanService : ILoanService
    {
        private static int _lastLoanId = 0;
        private static readonly List<Loan> _loans = new List<Loan>();
        private readonly IAccountService _accountService;

        public LoanService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public Loan RequestLoan(int accountId, decimal amount, decimal interestRate, int durationMonths)
        {
            var account = _accountService.GetAccountById(accountId);

            if (account == null)
                return null; 

            var loan = new Loan
            {
                LoanId = GenerateLoanId(),
                AccountId = accountId,
                Amount = amount,
                InterestRate = interestRate,
                DurationMonths = durationMonths,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(durationMonths),
                MonthlyPayment = CalculateMonthlyPayment(amount, interestRate, durationMonths),
                IsPaid = false
            };

            account.Balance += amount;

            _loans.Add(loan);
            return loan;
        }

        public List<Loan> GetAccountLoans(int accountId)
        {
            return _loans.Where(l => l.AccountId == accountId).ToList();
        }

        private int GenerateLoanId()
        {
            _lastLoanId++;
            return _lastLoanId;
        }

        private decimal CalculateMonthlyPayment(decimal amount, decimal interestRate, int durationMonths)
        {

            return Math.Round((amount * (1 + interestRate / 100)) / durationMonths, 2);
        }
    }
}
