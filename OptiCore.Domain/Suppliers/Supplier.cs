using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Inventory;

namespace OptiCore.Domain.Suppliers
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
      
        // Add any other properties specific to a supplier

        public List<Product> Products { get; set; } = new List<Product>();
    }
}