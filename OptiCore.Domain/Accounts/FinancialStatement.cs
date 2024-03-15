using OptiCore.Domain.Core;

namespace OptiCore.Domain.Accounts
{
    public class FinancialStatement : AuditEntity
    {
        public decimal TotalAssets { get; set; }
        public decimal TotalLiabilities { get; set; }
        public decimal NetIncome { get; set; }
        // Add any other properties or methods specific to a financial statement
    }
}