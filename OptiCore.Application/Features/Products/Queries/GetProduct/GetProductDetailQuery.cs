using MediatR;
using OptiCore.Application.Features.Products.Queries.GetAllProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Products.Queries.GetProduct
{
    public record GetProductDetailQuery(string productCode) : IRequest<ProductDetailDTO>;
}
