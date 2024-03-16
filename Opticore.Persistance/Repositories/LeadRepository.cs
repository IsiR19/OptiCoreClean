using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Domain.Leads;
using OptiCore.Domain.Users;

namespace Opticore.Persistance.Repositories
{
    public class LeadRepository : GenericRepository<Lead>, ILeadRepository
    {
        public LeadRepository(OptiCoreDbContext context) : base(context)
        {
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<LeadSource> GetSourceAsync(int sourceId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}