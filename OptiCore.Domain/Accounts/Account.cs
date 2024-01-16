using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Accounts
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        // Add any other properties or methods specific to an account
    }
}
