using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.Services.MobileTopUpService
{
    public interface IMobileTopUpService
    {
        void TopUpMobile(int accountId, string phoneNumber, decimal amount);
        List<MobileTopUp> GetMobileTopUpHistory(int accountId);
    }
}
