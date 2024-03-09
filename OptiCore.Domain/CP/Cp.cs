using OptiCore.Domain.Agents;
using OptiCore.Domain.Core;
using OptiCore.Domain.HeadOffices;

namespace OptiCore.Domain.CP
{
    public class Cp : AuditEntity
    {
        public int HeadOfficeId { get; set; } 
        public string Name { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public virtual HeadOffice HeadOffice { get; set; }

        public virtual IReadOnlyCollection<Agent> Agents => _agents.AsReadOnly();

        private readonly List<Agent> _agents = new List<Agent>();
    }
}