using OptiCore.Domain.Core;

namespace OptiCore.Domain.Inventory
{
    public class InventoryItem : AuditEntity
    {
        public int Quantity { get; set; }
        // Add any other properties specific to an inventory item

        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
    }
}