using BankApp.Services.ContactService;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase, IContactController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{accountID}/getContacts")]
        public IActionResult GetContacts(int accountID)
        {
            var contacts = _contactService.GetContacts(accountID);
            return Ok(contacts);
        }
    }
}
