using OptiCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Abstractions.Contracts.Persistance
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetRelatedUsersAsync(int userId);
    }
}
