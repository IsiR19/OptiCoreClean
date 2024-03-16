using MediatR;

namespace OptiCore.Application.Features.HeadOffices.Command.DeleteHeadOffice
{
    public class DeleteHeadOfficeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}