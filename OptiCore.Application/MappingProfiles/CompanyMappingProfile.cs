using AutoMapper;
using FluentValidation;
using OptiCore.Application.Features.Companies.Commands.CreateCompany;
using OptiCore.Application.Features.Companies.Commands.UpdateCompany;
using OptiCore.Application.Models;
using OptiCore.Application.Models.Companies;
using OptiCore.Domain.Addresses;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Contact_Details;
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
            CreateMap<Company,UpdateCompanyCommand>().ReverseMap()
                .ForMember(dest => dest.LinkedCompanies, opt => opt.Ignore())
                .AfterMap((src, dest) => {
                    foreach (var linkedCompanyDto in src.LinkedCompanies)
                    {
                        var linkedCompany = new Company
                        {
                            Name = linkedCompanyDto.Name,
                            RegistrationNumber = linkedCompanyDto.RegistrationNumber,
                            CompanyType = linkedCompanyDto.CompanyType,
                            IsActive = linkedCompanyDto.IsActive,
                            Id = linkedCompanyDto.Id
                
                        };
                         dest.AddLinkedCompany(linkedCompany);
                    }
                });
            CreateMap<Company, CompanyDetailDto>().ReverseMap().ForMember(dest => dest.LinkedCompanies, opt => opt.MapFrom(src => src.LinkedCompanies));
            CreateMap<Company, CompanyDto>().ReverseMap().ForMember(dest => dest.LinkedCompanies, opt => opt.MapFrom(src => src.LinkedCompanies));

            CreateMap<ContactDetail, ContactDetailDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();

        }
    }
}
