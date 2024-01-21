using System.Collections.Generic;

namespace BankApp.Services.TransactionService
{
    public interface ITransactionService
    {
        (bool Success, int TransactionId, string ErrorMessage) TransferFunds(int sourceAccountId, int destinationAccountId, decimal amount);

        List<Transaction> GetAccountTransactions(int accountId);

        Account GetAccountOwner(int accountId);
    }
}
