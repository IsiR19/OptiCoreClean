using MediatR;
using OptiCore.Application.Features.Products.Queries.GetAllProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Users.Queries.GetUser
{
    public record GetUserDetailQuery(int id) : IRequest<GetUserDetailDTO>;
}
