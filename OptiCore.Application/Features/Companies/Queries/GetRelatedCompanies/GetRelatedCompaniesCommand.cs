using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Application.Features.Companies.Queries.GetCompany;
using OptiCore.Application.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Queries.GetRelatedCompanies
{
    public class GetRelatedCompaniesCommand : IRequestHandler<GetRelatedCompaniesQuery,List<CompanyDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetRelatedCompaniesCommand(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyDto>> Handle(GetRelatedCompaniesQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.CompanyId);
            if (company == null)
            {
                throw new NotFoundException(nameof(company),request.CompanyId);
            }

            var data = await _companyRepository.GetLinkedCompanies(request.CompanyId);

            var response = _mapper.Map<List<CompanyDto>>(data);

            return response;

        }
    }
}
