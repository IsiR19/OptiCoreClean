using AutoMapper;
using OptiCore.Application.Features.Cps.Commands.CreateCP;
using OptiCore.Application.Features.Cps.Queries.GetCPById;
using OptiCore.Domain.CP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.MappingProfiles
{
    public class CPMappingProfile : Profile
    {
        public CPMappingProfile()
        {
            CreateMap<CreateCPCommand,Cp>().ReverseMap();
            CreateMap<UpdateCPCommand,Cp>().ReverseMap();
            CreateMap<CPDTO,Cp>().ReverseMap();
        }
    }
}
