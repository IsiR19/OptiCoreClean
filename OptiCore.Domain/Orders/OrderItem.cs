using OptiCore.Domain.Inventory;

namespace OptiCore.Domain.Orders
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        // Add any other properties specific to an order item

        public int OrderId { get; set; }
        public Order Order { get; set; } = new Order();

        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
    }
}