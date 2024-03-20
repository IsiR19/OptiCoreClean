using AutoMapper;
using MediatR;
using Opticore.Infrastructure.Logging;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Application.Features.Products.Commands.CreateProduct;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand,CreateCompanyCommand>
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

        public async Task<CreateCompanyCommand> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            //TODO: Include automatic commission structure for hierarchy
            //Will be editable on the front end but will not exist on initial creation

            _logger.LogInformation($"Validating company {request.Name} - {request.RegistrationNumber}");
            var validator = new CreateCompanyValidator(_companyRepository);
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning($"Failed to validate company({request.Name}): {validationResult}");
                throw new BadRequestException("Invalid company", validationResult);
            }


            _logger.LogInformation($"Mapping company({request.Name})");
            var data = _mapper.Map<Company>(request);
            _logger.LogInformation($"Saving company({request.Name})");
            await _companyRepository.CreateAsync(data);

            var response = _mapper.Map<CreateCompanyCommand>(data);

            return response;
        }
    }
}
