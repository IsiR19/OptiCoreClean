namespace OptiCore.Domain.Accounts
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        // Add any other properties or methods specific to a transaction
    }
}