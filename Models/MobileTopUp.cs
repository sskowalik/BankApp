using System;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class MobileTopUp
    {
        public int MobileTopUpId { get; set; }
        public int AccountId { get; set; }
        
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Phone number must have 9 digits")]
        public string PhoneNumber { get; set; }

        public decimal Amount { get; set; }
        public DateTime TopUpDate { get; set; }
    }
}
