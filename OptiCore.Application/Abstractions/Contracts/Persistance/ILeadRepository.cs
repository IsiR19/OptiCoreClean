using OptiCore.Domain.Leads;
using OptiCore.Domain.Users;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface ILeadRepository : IRepository<Lead>
    {


        // Retrieves the LeadSource entity by its ID
        Task<LeadSource> GetSourceAsync(int sourceId);

        // Retrieves the User entity by its ID
        Task<User> GetUserAsync(int userId);

        // The UnitOfWork property or method ensures that the repository can participate in transactions
        IUnitOfWork UnitOfWork { get; }
    }
}