using OptiCore.Domain.CP;

namespace OptiCore.Domain.Agents
{
    public class Agent
    {
        public int AgentId { get; set; } // Primary key
        public int? ParentAgentId { get; set; } // Foreign key for self-referencing (nullable for top-level agents)
        public int CPId { get; set; } // Foreign key to CP
        public string AgentName { get; set; }

        // Navigation properties
        public virtual Cp CP { get; set; }

        public virtual Agent ParentAgent { get; set; }
        public virtual ICollection<Agent> SubAgents { get; set; }
    }
}