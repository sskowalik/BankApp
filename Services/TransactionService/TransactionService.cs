using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private static int _lastTransactionId = 0;
        private static readonly List<Transaction> _transactions = new List<Transaction>();
        private readonly IAccountService _accountService; 

        public TransactionService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public (bool Success, int TransactionId, string ErrorMessage) TransferFunds(int sourceAccountId, int destinationAccountId, decimal amount)
        {
            var sourceAccount = _accountService.GetAccountById(sourceAccountId);
            var destinationAccount = _accountService.GetAccountById(destinationAccountId);

            if (sourceAccount == null || destinationAccount == null)
                return (false, 0, "Source or destination account not found");

            if (sourceAccount.Balance < amount)
                return (false, 0, "Insufficient funds");

            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            var newTransaction = new Transaction
            {
                TransactionId = GenerateTransactionId(),
                SourceAccountId = sourceAccountId,
                DestinationAccountId = destinationAccountId,
                Amount = amount,
                Date = DateTime.Now
            };

            _transactions.Add(newTransaction);

            return (true, newTransaction.TransactionId, null);
        }

        public List<Transaction> GetAccountTransactions(int accountId)
        {
            return _transactions.FindAll(t => t.SourceAccountId == accountId || t.DestinationAccountId == accountId);
        }

        public Account GetAccountOwner(int accountId)
        {
            return _accountService.GetAccountById(accountId);
        }

        public Account GetAccountById(int accountId)
        {
            return _accountService.GetAccountById(accountId);
        }

        private int GenerateTransactionId()
        {
            _lastTransactionId++;
            return _lastTransactionId;
        }
    }
}
