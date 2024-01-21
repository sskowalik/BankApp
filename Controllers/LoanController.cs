using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using BankApp.Services.LoanService;

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost("request")]
        public IActionResult RequestLoan([FromBody] LoanRequest request)
        {
            var result = _loanService.RequestLoan(
                request.AccountId,
                request.Amount,
                request.InterestRate,
                request.DurationMonths
            );

            if (result != null)
                return Ok(new { Message = "Loan requested successfully", LoanId = result.LoanId });
            else
                return BadRequest(new { Message = "Invalid account or request parameters" });
        }

        [HttpGet("{accountID}/loans")]
        public IActionResult GetAccountLoans(int accountID)
        {
            var loans = _loanService.GetAccountLoans(accountID);
            return Ok(loans);
        }
    }

    public class LoanRequest
    {
        [Required(ErrorMessage = "Account ID is required")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Interest Rate is required")]
        [Range(0.1, 100, ErrorMessage = "Interest Rate must be between 0.1 and 100")]
        public decimal InterestRate { get; set; }

        [Required(ErrorMessage = "Duration Months is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration Months must be greater than 0")]
        public int DurationMonths { get; set; }
    }
}
