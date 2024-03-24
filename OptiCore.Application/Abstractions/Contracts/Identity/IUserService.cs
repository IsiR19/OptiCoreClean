using OptiCore.Domain.Users;
namespace OptiCore.Application.Abstractions.Contracts.Identity
{
    public interface IUserService: Auth.Core.Interfaces.IUserService
    {
        Task<List<User>> GetUsers();

        Task<User> GetUser(string userId);
    }
}