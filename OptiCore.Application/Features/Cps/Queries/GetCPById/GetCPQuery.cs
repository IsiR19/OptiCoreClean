using MediatR;

namespace OptiCore.Application.Features.Cps.Queries.GetCPById
{
    public record GetCPQuery(int id) : IRequest<CPDTO>;
}