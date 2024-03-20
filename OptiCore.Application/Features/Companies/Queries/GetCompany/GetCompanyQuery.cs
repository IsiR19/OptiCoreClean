using MediatR;
using OptiCore.Application.Features.Products.Queries.GetProduct;
using OptiCore.Application.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Queries.GetCompany
{
    public record GetCompanyQuery(int id) : IRequest<CompanyDetailDto>;
}
