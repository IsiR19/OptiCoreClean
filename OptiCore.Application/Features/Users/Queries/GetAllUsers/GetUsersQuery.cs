using MediatR;

namespace OptiCore.Application.Features.Users.Queries.GetAllUsers
{
    public record GetUsersQuery(int userId) : IRequest<List<GetUsersDTO>>;
}