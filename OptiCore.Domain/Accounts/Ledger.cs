using OptiCore.Domain.Core;

namespace OptiCore.Domain.Accounts
{
    public class Ledger : AuditEntity
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        // Add any other properties or methods specific to a ledger
    }
}