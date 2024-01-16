using OptiCore.Domain.Core;
using OptiCore.Domain.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Inventory
{
    public class Product : AuditEntity
    {
        public int ProductCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        // Add any other properties specific to a product
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = new Supplier();

        public List<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
    }
}
