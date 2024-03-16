using MediatR;
using OptiCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
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
