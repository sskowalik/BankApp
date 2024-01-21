using System.Collections.Generic;
using BankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public interface IContactController
    {
        IActionResult GetContacts(int accountID);
    }
}
