using AutoMapper;
using MediatR;
using OptiCore.Domain.Companies;
using Opticore.Infrastructure.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using OptiCore.Application.Models.Companies;
using OptiCore.Application.Abstractions.Contracts.Persistance;

namespace OptiCore.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyDetailDto>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IApplicationLogger<CreateCompanyHandler> _logger;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(ICompanyRepository companyRepository, IApplicationLogger<CreateCompanyHandler> logger, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CompanyDetailDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Creating company {request.Name}");

                var company = _mapper.Map<Company>(request);
                await _companyRepository.CreateAsync(company);

                _logger.LogInformation($"Company created with ID {company.Id}");

                var response = _mapper.Map<CompanyDetailDto>(company);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating company {request.Name}: {ex.Message}", ex);
                throw new ApplicationException("An error occurred when creating the company", ex);
            }
        }
    }
}
