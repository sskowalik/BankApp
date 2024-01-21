using System;
using System.Collections.Generic;

namespace BankApp.Models;

    public class Account
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public decimal Balance { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreateDate { get; set; }
    }

