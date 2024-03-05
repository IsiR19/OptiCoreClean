using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Messaging;
using OptiCore.Domain.Leads;
using OptiCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<LeadStatus> GetStatusAsync(int statusId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
