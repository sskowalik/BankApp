using System;
using System.Collections.Generic;
using System.Linq;
using BankApp.Models;

namespace BankApp.Services.ContactService
{
    public class ContactService : IContactService
    {
        private static readonly List<Contact> _contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            var existingContact = _contacts.FirstOrDefault(c => c.AccountId == contact.AccountId && c.ContactId == contact.ContactId);

            if (existingContact == null)
            {
                _contacts.Add(contact);
            }
        }

        public List<Contact> GetContacts(int accountId)
        {
            return _contacts.Where(c => c.AccountId == accountId).ToList();
        }
    }
}
