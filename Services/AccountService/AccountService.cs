using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Services.AccountService
{
      public class AccountService : IAccountService
    {
        private static int _lastAccountId = 0;
        private static readonly List<Account> _accounts = new List<Account>();

        public Account CreateAccount(string? _name, string? surname, string? password, decimal balance, DateTime birthdate, DateTime createDate)
        {
            var newAccount = new Account
            {
                Id = GenerateAccountId(),
                Name = _name,
                Surname = surname,
                Password = password,
                Balance = balance,
                Birthdate = birthdate,
                CreateDate = createDate,
            };
            _accounts.Add(newAccount);


            return newAccount;
        }

        public Account GetAccountById(int accountId)
        {
            return _accounts.FirstOrDefault(a => a.Id == accountId);
        }

        public bool UpdateAccount(int accountId, Account updatedAccount)
        {
            var existingAccount = _accounts.FirstOrDefault(a => a.Id == accountId);

            if (existingAccount != null)
            {
                existingAccount.Name = updatedAccount.Name;
                existingAccount.Surname = updatedAccount.Surname;
                existingAccount.Password = updatedAccount.Password;
                existingAccount.Birthdate = updatedAccount.Birthdate;

                return true;
            }

            return false;
        }

        public bool DeleteAccount(int accountId)
        {
            var accountToRemove = _accounts.FirstOrDefault(a => a.Id == accountId);

            if (accountToRemove != null)
            {
                _accounts.Remove(accountToRemove);
                return true;
            }

            return false;
        }

        public decimal GetAccountBalance(int accountId)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == accountId);

            return account?.Balance ?? 0.0m;
        }

        
        public List<Account> GetAllAccounts()
        {
            return _accounts;
        }

        private int GenerateAccountId()
        {
            _lastAccountId++;
            return _lastAccountId;
        }
    }
}
