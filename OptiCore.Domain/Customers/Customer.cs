using OptiCore.Domain.Orders;
using OptiCore.Domain.Payments;

namespace OptiCore.Domain.Customers
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // Add any other properties specific to a customer

        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Payment> Payments { get; set; } = new List<Payment>();
    }
}