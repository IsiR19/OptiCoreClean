using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Inventory
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public int Quantity { get; set; }
        // Add any other properties specific to an inventory item

        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
