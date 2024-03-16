using AutoMapper;
using OptiCore.Application.Features.HeadOffices.Queries.GetHeadOffice;
using OptiCore.Domain.HeadOffices;

namespace OptiCore.Application.MappingProfiles
{
    public class HeadOfficeDetailMappingProfile : Profile
    {
        public HeadOfficeDetailMappingProfile()
        {
            CreateMap<HeadOfficeDetailDTO, HeadOffice>().ReverseMap();
        }
    }
}