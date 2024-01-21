using System;
using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.Services.MobileTopUpService
{
    public class MobileTopUpService : IMobileTopUpService
    {
        private static int _lastTopUpId = 0;
        private static readonly List<MobileTopUp> _topUpHistory = new List<MobileTopUp>();
        private readonly IAccountService _accountService;

        public MobileTopUpService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void TopUpMobile(int accountId, string phoneNumber, decimal amount)
        {
            var account = _accountService.GetAccountById(accountId);

            if (account == null)
            {
                throw new InvalidOperationException("Account not found");
            }

            if (amount <= 0)
            {
                throw new InvalidOperationException("Invalid top-up amount");
            }

            if (account.Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            account.Balance -= amount;

            var newTopUp = new MobileTopUp
            {
                MobileTopUpId = GenerateTopUpId(),
                AccountId = accountId,
                PhoneNumber = phoneNumber,
                Amount = amount,
                TopUpDate = DateTime.Now
            };

            _topUpHistory.Add(newTopUp);
        }

        public List<MobileTopUp> GetMobileTopUpHistory(int accountId)
        {
            return _topUpHistory.FindAll(topUp => topUp.AccountId == accountId);
        }

        private int GenerateTopUpId()
        {
            _lastTopUpId++;
            return _lastTopUpId;
        }
    }
}
