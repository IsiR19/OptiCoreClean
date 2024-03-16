using MediatR;

namespace OptiCore.Application.Features.Users.Queries.GetUser
{
    public record GetUserDetailQuery(int id) : IRequest<GetUserDetailDTO>;
}