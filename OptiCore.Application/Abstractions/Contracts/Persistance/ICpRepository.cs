using OptiCore.Domain.Agents;
using OptiCore.Domain.CP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface ICpRepository : IRepository<Cp>
    {
        Task<bool> IsCPUnique(string name);
        Task<IReadOnlyList<Cp>> GetCpByHeadOfficeId(int HeadOfficeId);
    }
}
