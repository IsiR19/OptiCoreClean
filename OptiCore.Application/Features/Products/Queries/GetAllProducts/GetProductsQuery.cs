using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Products.Queries.GetAllProducts
{
    public record GetProductsQuery : IRequest<List<ProductsDTO>>;
 
}
