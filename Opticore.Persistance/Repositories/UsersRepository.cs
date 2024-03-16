using Opticore.Persistence.DatabaseContext;
using Opticore.Persistence.Repositories;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Domain.Users;

namespace Opticore.Persistance.Repositories
{
    internal class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(OptiCoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetRelatedUsersAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), userId);
            }

            var relatedUsers = new List<User>();
            await GetSubordinatesAsync(user, relatedUsers);

            return relatedUsers;
        }

        private async Task GetSubordinatesAsync(User user, List<User> relatedUsers)
        {
            // Include the user's subordinates in the related users list
            var subordinates = _context.UserHierarchy
                .Where(uh => uh.ParentUserId == user.Id)
                .Select(uh => uh.ChildUser);

            foreach (var subordinate in subordinates)
            {
                relatedUsers.Add(subordinate);
                await GetSubordinatesAsync(subordinate, relatedUsers);
            }
        }
    }
}