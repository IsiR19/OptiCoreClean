using MediatR;

namespace OptiCore.Application.Features.Products.Queries.GetProduct
{
    public record GetProductDetailQuery(string productCode) : IRequest<ProductDetailDTO>;
}