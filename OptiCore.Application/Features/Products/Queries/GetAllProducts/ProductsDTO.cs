namespace OptiCore.Application.Features.Products.Queries.GetAllProducts
{
    public class ProductsDTO
    {
        public int ProductCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}