using OptiCore.Domain.Users;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetRelatedUsersAsync(int userId);
    }
}