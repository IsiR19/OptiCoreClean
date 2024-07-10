using FluentValidation;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Validation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator() 
        { 
            RuleFor(company => company.Name).NotEmpty();
            RuleFor(company => company.LinkedCompanies)
            .Must((company, linkedCompanies) => BeValidCompanyLink(company, linkedCompanies))
            .WithMessage("Invalid company link based on company types.");
        }
        private bool BeValidCompanyLink(Company company, IReadOnlyList<Company> linkedCompanies)
        {
            return linkedCompanies.All(linkedCompany =>
            (company.CompanyType == CompanyType.ChannelPartner &&
            (linkedCompany.CompanyType == CompanyType.ChannelPartner || linkedCompany.CompanyType == CompanyType.Agent)) ||
            (company.CompanyType == CompanyType.Agent && linkedCompany.CompanyType == CompanyType.Agent));
        }
    }
}
