using AutoMapper;
using FluentValidation;
using OptiCore.Application.Features.Companies.Commands.CreateCompany;
using OptiCore.Application.Features.Companies.Commands.UpdateCompany;
using OptiCore.Application.Models.Companies;
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
            //TODO: need to include mapping for hierary
            CreateMap<Company , CreateCompanyCommand>().ReverseMap();
            CreateMap<Company,UpdateCompanyCommand>().ReverseMap();
            CreateMap<Company, CompanyDetailDto>().ReverseMap();
            CreateMap<Company,CompanyDto>().ReverseMap();

        }
    }
}
