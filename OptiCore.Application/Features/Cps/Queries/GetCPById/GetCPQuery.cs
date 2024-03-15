using MediatR;
using OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Cps.Queries.GetCPById
{
    public record GetCPQuery(int id) : IRequest<CPDTO>;
}
