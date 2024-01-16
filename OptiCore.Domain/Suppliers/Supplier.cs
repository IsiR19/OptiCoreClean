using OptiCore.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Suppliers
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        // Add any other properties specific to a supplier

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
