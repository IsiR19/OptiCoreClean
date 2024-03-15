using OptiCore.Domain.Core;

namespace OptiCore.Domain.Accounts
{
    public class Account : AuditEntity
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        // Add any other properties or methods specific to an account
    }
}