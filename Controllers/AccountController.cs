using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("create")]
        public IActionResult CreateAccount([FromBody] AccountCreateRequest request)
        {
            var newAccount = _accountService.CreateAccount(
                request.Name,
                request.Surname,
                request.Password,
                request.Balance,
                request.Birthdate,
                request.CreateDate
            );

            return Ok(new { Message = "Account created successfully", AccountID = newAccount.Id });
        }

        [HttpPut("{accountID}/update")]
        public IActionResult UpdateAccount(int accountID, [FromBody] AccountUpdateRequest request)
        {
            var updatedAccount = new Account
            {
                Name = request.Name,
                Surname = request.Surname,
                Password = request.Password,
                Birthdate = request.Birthdate
            };

            var result = _accountService.UpdateAccount(accountID, updatedAccount);

            if (result)
                return Ok(new { Message = "Account updated successfully" });
            else
                return NotFound(new { Message = "Account not found" });
        }

        [HttpDelete("{accountID}/delete")]
        public IActionResult DeleteAccount(int accountID)
        {
            var result = _accountService.DeleteAccount(accountID);

            if (result)
                return Ok(new { Message = "Account deleted successfully" });
            else
                return NotFound(new { Message = "Account not found" });
        }

        [HttpGet("{accountID}/balance")]
        public IActionResult GetAccountBalance(int accountID)
        {
            var balance = _accountService.GetAccountBalance(accountID);
            return Ok(new { Balance = balance });
        }


        [HttpGet("all")]
        public IActionResult GetAllAccounts()
        {
            var accounts = _accountService.GetAllAccounts();
            return Ok(accounts);
        }
    }

    public class AccountCreateRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(50, ErrorMessage = "Surname cannot be longer than 50 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        public DateTime Birthdate { get; set; }

        public DateTime CreateDate { get; set; }
    }

    public class AccountUpdateRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
