using OptiCore.Domain.Leads;
using OptiCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Abstractions.Messaging
{
    public interface ILeadRepository : IRepository<Lead> 
    {
       
        // Retrieves the LeadStatus entity by its ID
        Task<LeadStatus> GetStatusAsync(int statusId);

        // Retrieves the LeadSource entity by its ID
        Task<LeadSource> GetSourceAsync(int sourceId);

        // Retrieves the User entity by its ID
        Task<User> GetUserAsync(int userId);

        // The UnitOfWork property or method ensures that the repository can participate in transactions
        IUnitOfWork UnitOfWork { get; }
    }

}
