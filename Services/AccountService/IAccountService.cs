namespace BankApp.Services.AccountService
{
public interface IAccountService
    {
        Account CreateAccount(string? _name, string? surname, string? password, decimal balance, DateTime birthdate, DateTime createDate);
        Account GetAccountById(int accountId);
        bool UpdateAccount(int accountId, Account updatedAccount);
        bool DeleteAccount(int accountId);
        decimal GetAccountBalance(int accountId);
        List<Account> GetAllAccounts();

    }
}
