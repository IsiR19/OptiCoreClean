using OptiCore.Domain.Core;

namespace OptiCore.Domain.Agents
{
    public class Agent : AuditEntity
    {
        public string AgentName { get; set; }
        public int? ParentAgentId { get; set; }
        public int CPId { get; set; }
        public bool IsActive { get; set; }
        public bool IsCP { get; set; }
    }
}