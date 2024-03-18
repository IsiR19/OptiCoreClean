using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Application.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCommand,Unit>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            //Get Record by Id
            var company = await _companyRepository.GetByIdAsync(request.Id);
            //Validate Record Exists
            if (company == null)
                throw new NotFoundException(nameof(company), request.Id);
            //Remove Record from Database
            await _companyRepository.DeleteAsync(company);

            return Unit.Value;
        }
    }
}
