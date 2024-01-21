using System;
using System.Collections.Generic;

namespace BankApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int SourceAccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}

