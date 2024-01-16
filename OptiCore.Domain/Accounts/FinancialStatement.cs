using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Accounts
{
    public class FinancialStatement
    {
        public decimal TotalAssets { get; set; }
        public decimal TotalLiabilities { get; set; }
        public decimal NetIncome { get; set; }
        // Add any other properties or methods specific to a financial statement
    }
}
