using MediatR;
using OptiCore.Application.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : UsersDTO, IRequest<UpdateUserCommand>
    {
        public int UserId { get; set; }
    }
}
