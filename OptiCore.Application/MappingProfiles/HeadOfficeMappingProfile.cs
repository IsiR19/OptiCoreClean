using AutoMapper;
using OptiCore.Application.Features.HeadOffices.Command.CreatHeadOffice;
using OptiCore.Application.Features.HeadOffices.Command.UpdateHeadOffice;
using OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices;
using OptiCore.Application.Features.HeadOffices.Queries.GetHeadOffice;
using OptiCore.Domain.HeadOffices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.MappingProfiles
{
    public class HeadOfficeMappingProfile : Profile
    {
        public HeadOfficeMappingProfile()
        {
            CreateMap<CreateHeadOfficeCommand,HeadOffice>().ReverseMap();
            CreateMap<UpdateHeadOfficeCommand, HeadOffice>().ReverseMap();
            CreateMap<HeadOfficeDTO,HeadOffice>().ReverseMap();
        }
    }
}
