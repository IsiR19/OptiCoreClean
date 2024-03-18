using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Application.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Queries.GetCompany
{
    public class GetCompanyHandler : IRequestHandler<GetCompanyQuery,CompanyDetailDto>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDetailDto> Handle(GetCompanyQuery request,CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.id);
            if (company == null)
            {
                throw new NotFoundException(nameof(company),request.id);
            }

            var response = _mapper.Map<CompanyDetailDto>(company);
            return response;
        }
    }
}
