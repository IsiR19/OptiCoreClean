using MediatR;

namespace OptiCore.Application.Features.Products.Queries.GetAllProducts
{
    public record GetProductsQuery : IRequest<List<ProductsDTO>>;
}