using OptiCore.Domain.Core;
using OptiCore.Domain.Customers;

namespace OptiCore.Domain.Orders
{
    public class Order : AuditEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        // Add any other properties specific to an order

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}