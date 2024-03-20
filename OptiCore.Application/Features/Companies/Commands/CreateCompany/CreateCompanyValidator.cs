using FluentValidation;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

  
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(p => p.RegistrationNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }


    }
}
