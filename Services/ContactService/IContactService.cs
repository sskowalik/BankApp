using System.Collections.Generic;
using BankApp.Models;

namespace BankApp.Services.ContactService
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetContacts(int accountId);
    }
}
