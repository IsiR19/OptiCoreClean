using OptiCore.Domain.Suppliers;

namespace OptiCore.Application.Features.Products.Queries.GetProduct
{
    public class ProductDetailDTO
    {
        public int ProductCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Supplier Supplier { get; set; } = new Supplier();
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }
}