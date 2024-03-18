using MediatR;
using OptiCore.Application.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Queries.GetRelatedCompanies
{
    public class GetRelatedCompaniesQuery : IRequest<List<CompanyDto>>
    {
        public GetRelatedCompaniesQuery(int companyId)
        {
            
        }
        public int CompanyId { get; set; }
    }
}
