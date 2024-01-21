namespace BankApp.Models
{
    public class Loan
    {

        public int AccountId { get; set; }
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int DurationMonths { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public bool IsPaid { get; set; }
    }
}