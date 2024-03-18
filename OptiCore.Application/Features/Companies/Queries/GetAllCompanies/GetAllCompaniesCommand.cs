using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Features.Companies.Queries.GetCompany;
using OptiCore.Application.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Queries.GetAllCompanies
{
    public class GetAllCompaniesCommand : IRequestHandler<GetAllCompaniesQuery,List<CompanyDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetAllCompaniesCommand(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var data = await _companyRepository.GetAllAsync();

            //TODO: Add filtering to cater for companies allowed to see, we can use userId to get company and filter based on hierarchy, all children records
            // Also keep in mind the Tenant

            var response = _mapper.Map<List<CompanyDto>>(data);

            return response;
        }
    }
}
