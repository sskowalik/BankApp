using Microsoft.AspNetCore.Mvc;
using BankApp.Services.MobileTopUpService;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileTopUpController : ControllerBase
    {
        private readonly IMobileTopUpService _mobileTopUpService;

        public MobileTopUpController(IMobileTopUpService mobileTopUpService)
        {
            _mobileTopUpService = mobileTopUpService;
        }

        [HttpPost("topup")]
        public IActionResult TopUpMobile([FromBody] TopUpRequest request)
        {
            try
            {
                _mobileTopUpService.TopUpMobile(request.AccountId, request.PhoneNumber, request.Amount);
                return Ok(new { Message = "Mobile top-up successful" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{accountID}/topup-history")]
        public IActionResult GetMobileTopUpHistory(int accountID)
        {
            var topUpHistory = _mobileTopUpService.GetMobileTopUpHistory(accountID);
            return Ok(topUpHistory);
        }
    }

    public class TopUpRequest
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Phone number must have 9 digits")]
        public string PhoneNumber { get; set; }

        public decimal Amount { get; set; }
    }
}
