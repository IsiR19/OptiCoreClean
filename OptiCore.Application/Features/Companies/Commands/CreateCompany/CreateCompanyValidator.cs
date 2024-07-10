﻿using FluentValidation;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Models.Companies;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyValidator()
        {
            RuleFor(command => command.Name).NotEmpty().WithMessage("Company name is required.");
            RuleFor(command => command.RegistrationNumber).NotEmpty().WithMessage("Registration number is required.");
            RuleFor(company => company.LinkedCompanies)
            .Must((company, linkedCompanies) => BeValidCompanyLink(company, linkedCompanies))
            .WithMessage("Invalid company link based on company types.");
        }

        private bool BeValidCompanyLink(CompanyDto company, IReadOnlyList<CompanyDto> linkedCompanies)
        {
            return linkedCompanies.All(linkedCompany =>
            (company.CompanyType == CompanyType.ChannelPartner &&
            (linkedCompany.CompanyType == CompanyType.ChannelPartner || linkedCompany.CompanyType == CompanyType.Agent)) ||
            (company.CompanyType == CompanyType.Agent && linkedCompany.CompanyType == CompanyType.Agent));
        }


    }
}
