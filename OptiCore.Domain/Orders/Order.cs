using OptiCore.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        // Add any other properties specific to an order

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
