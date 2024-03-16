using OptiCore.Domain.Agents;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<bool> IsAgentUnique(string name);

        Task<IReadOnlyList<Agent>> GetAgentsByCPId(int cpId);
    }
}