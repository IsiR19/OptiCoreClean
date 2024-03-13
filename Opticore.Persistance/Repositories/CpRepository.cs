using Microsoft.EntityFrameworkCore;
using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Domain.CP;

namespace Opticore.Persistance.Repositories
{
    public class CpRepository : GenericRepository<Cp>, ICpRepository
    {
        public CpRepository(OptiCoreDbContext context) : base(context)
        {

        }
        public async Task<IReadOnlyList<Cp>> GetCpByHeadOfficeId(int HeadOfficeId)
        {
            return await _context.Cp.Where(c => c.HeadOfficeId == HeadOfficeId).ToListAsync(); 
        }

        public async Task<bool> IsCPUnique(string name)
        {
            return await _context.Cp.AnyAsync(c => c.Name == name);
        }
    }
}
