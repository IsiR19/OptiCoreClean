using MediatR;
using OptiCore.Domain.Enums;

namespace OptiCore.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public int? ParentUserId { get; set; }
        public List<int> SubordinateUserIds { get; set; }
        public int SubordinateCount { get; set; }
        public decimal TotalCommission { get; set; }
    }
}