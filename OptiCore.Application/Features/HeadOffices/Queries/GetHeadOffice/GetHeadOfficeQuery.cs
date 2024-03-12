using MediatR;
using OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices;
using OptiCore.Application.Features.Products.Queries.GetProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.HeadOffices.Queries.GetHeadOffice
{

        public record GetHeadOfficeQuery(int id) : IRequest<HeadOfficeDTO>;
    
}
