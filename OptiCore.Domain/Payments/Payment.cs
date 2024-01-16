using OptiCore.Domain.Customers;
using OptiCore.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Payments
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        // Add any other properties specific to a payment

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();

        public int OrderId { get; set; }
        public Order Order { get; set; } = new Order();
    }
}
