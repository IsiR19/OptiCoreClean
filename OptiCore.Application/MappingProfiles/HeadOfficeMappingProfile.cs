using AutoMapper;
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
            CreateMap<HeadOfficeDetailMappingProfile,HeadOffice>().ReverseMap();
        }
    }
}
