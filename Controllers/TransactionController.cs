using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using BankApp.Services.TransactionService;
using BankApp.Services.ContactService;

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IContactService _contactService;

        public TransactionController(ITransactionService transactionService, IContactService contactService)
        {
            _transactionService = transactionService;
            _contactService = contactService;
        }

        [HttpPost("transfer")]
        public IActionResult TransferFunds([FromBody] TransferRequest request)
        {
            var result = _transactionService.TransferFunds(
                request.SourceAccountId,
                request.DestinationAccountId,
                request.Amount
            );

            if (result.Success)
            {
                var sourceAccountOwner = _transactionService.GetAccountOwner(request.SourceAccountId);
                var destinationAccountOwner = _transactionService.GetAccountOwner(request.DestinationAccountId);

                var contact = new Contact
                {
                    AccountId = request.SourceAccountId,
                    ContactId = request.DestinationAccountId,
                    ContactName = destinationAccountOwner.Name,
                    ContactSurname = destinationAccountOwner.Surname,
                    AccountOwnerName = sourceAccountOwner.Name,
                    AcconutOwnerSurname = sourceAccountOwner.Surname
                };

                _contactService.AddContact(contact);

                return Ok(new { Message = "Funds transferred successfully", TransactionId = result.TransactionId });
            }
            else
            {
                return BadRequest(new { Message = result.ErrorMessage });
            }
        }

        [HttpGet("{accountID}/transactions")]
        public IActionResult GetAccountTransactions(int accountID)
        {
            var transactions = _transactionService.GetAccountTransactions(accountID);
            return Ok(transactions);
        }
    }

    public class TransferRequest
    {
        [Required(ErrorMessage = "Source Account ID is required")]
        public int SourceAccountId { get; set; }

        [Required(ErrorMessage = "Destination Account ID is required")]
        public int DestinationAccountId { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
    }
}
