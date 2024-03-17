using MediatR;
using OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices;

namespace OptiCore.Application.Features.HeadOffices.Queries.GetHeadOffice
{
    public record GetHeadOfficeQuery(int id) : IRequest<HeadOfficeDTO>;
}