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

    }
}