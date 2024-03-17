using MediatR;
using OptiCore.Application.Models.Users;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Enums;

namespace OptiCore.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : UsersDTO, IRequest<CreateUserCommand> 
    {
    }
}

