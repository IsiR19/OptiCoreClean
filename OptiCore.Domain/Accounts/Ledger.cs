using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Accounts
{
    public class Ledger
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        // Add any other properties or methods specific to a ledger
    }
}
