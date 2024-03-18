using AutoMapper;
using FluentValidation;
using OptiCore.Application.Features.Companies.Commands.CreateCompany;
using OptiCore.Domain.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.MappingProfiles
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company , CreateCompanyCommand>().ReverseMap();

        }
    }
}
