using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Features.Products.Commands.UpdateProduct;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand,UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCompanyCommand> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Company>(request);

            await _companyRepository.UpdateAsync(data);

            var response = _mapper.Map<UpdateCompanyCommand>(data);

            return response;
        }
    }
}
