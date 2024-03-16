using OptiCore.Domain.Users;

namespace OptiCore.Application.Abstractions.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task<User> GetUser(string userId);
    }
}