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
                .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => src.ContactDetails))
                .ReverseMap();
                //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            // Call calculate commision service for this
            //.ForMember(dest => dest.TotalCommission, opt => opt.MapFrom(src => CalculateTotalCommission(src)));

            CreateMap<User, GetUserDetailDTO>()
                .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => src.ContactDetails))
                .ReverseMap();
            //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            //.ForMember(dest => dest.ParentUserId, opt => opt.MapFrom(src => src.ParentHierarchy != null ? (int?)src.ParentHierarchy.ParentUserId : null))
            //.ForMember(dest => dest.SubordinateUserIds, opt => opt.MapFrom(src => src.ChildHierarchies.Select(h => h.ChildUserId)))
            //.ForMember(dest => dest.SubordinateCount, opt => opt.MapFrom(src => src.ChildHierarchies.Count));

            CreateMap<User, CreateUserCommand>()
                .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => src.ContactDetails))
                .ReverseMap();
        }
    }
}