using MediatR;

namespace OptiCore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public int ProductCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Add any other properties specific to a product
        public int SupplierId { get; set; }
    }
}