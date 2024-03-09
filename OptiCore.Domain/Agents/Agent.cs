using OptiCore.Domain.Core;
using OptiCore.Domain.CP;

namespace OptiCore.Domain.Agents
{
    public class Agent : AuditEntity
    {
        public int? ParentAgentId { get; set; } 
        public int CPId { get; set; } 
        public bool IsActive { get; set; }
        public bool IsCP { get; set; }
        public string AgentName { get; set; }

        // Navigation properties
        public virtual Cp CP { get; set; }

    }
}