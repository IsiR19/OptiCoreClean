namespace OptiCore.Domain.Accounts
{
    public class Ledger
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        // Add any other properties or methods specific to a ledger
    }
}