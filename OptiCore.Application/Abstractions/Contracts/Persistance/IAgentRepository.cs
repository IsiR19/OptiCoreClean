using OptiCore.Domain.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<bool> IsAgentUnique(string name);
        Task<IReadOnlyList<Agent>> GetAgentsByCPId(int cpId);
    }
}
