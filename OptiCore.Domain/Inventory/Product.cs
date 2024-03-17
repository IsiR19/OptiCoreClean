using OptiCore.Domain.Core;

namespace OptiCore.Domain.Inventory
{
    public class Product : AuditEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public List<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
    }
}