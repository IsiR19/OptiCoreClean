using MediatR;

namespace OptiCore.Application.Features.Cps.Commands.DeleteCP
{
    public class DeleteCPCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}