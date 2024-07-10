using AutoMapper;
using OptiCore.Application.Features.Users.Commands.CreateUser;
using OptiCore.Application.Features.Users.Queries.GetAllUsers;
using OptiCore.Application.Features.Users.Queries.GetUser;
using OptiCore.Domain.Users;

namespace OptiCore.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUsersDTO>()
                //.ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => src.ContactDetails))
                .ReverseMap();

            CreateMap<User, GetUserDetailDTO>()
                //.ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => src.ContactDetails))
                .ReverseMap();

            CreateMap<User, CreateUserCommand>()
                //.ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => src.ContactDetails))
                .ReverseMap();
        }
    }
}