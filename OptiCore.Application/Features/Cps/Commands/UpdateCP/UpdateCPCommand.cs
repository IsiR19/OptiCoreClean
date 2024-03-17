using MediatR;
using OptiCore.Domain.Agents;

namespace OptiCore.Application.Features.Cps.Commands.CreateCP
{
    public class UpdateCPCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int HeadOfficeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;

        private readonly List<Agent> _agents = new List<Agent>();
    }
}