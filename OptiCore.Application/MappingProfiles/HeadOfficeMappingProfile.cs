using AutoMapper;
using OptiCore.Application.Features.HeadOffices.Command.CreatHeadOffice;
using OptiCore.Application.Features.HeadOffices.Command.UpdateHeadOffice;
using OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices;
using OptiCore.Domain.HeadOffices;

namespace OptiCore.Application.MappingProfiles
{
    public class HeadOfficeMappingProfile : Profile
    {
        public HeadOfficeMappingProfile()
        {
            CreateMap<CreateHeadOfficeCommand, HeadOffice>().ReverseMap();
            CreateMap<UpdateHeadOfficeCommand, HeadOffice>().ReverseMap();
            CreateMap<HeadOfficeDTO, HeadOffice>().ReverseMap();
        }
    }
}