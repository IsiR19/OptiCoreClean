using Auth.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces
{
    public interface IUserService
    {
        Task<IUser?> GetUserByUuidUIDAsync(string uuid);
        Task<IEnumerable<string>> GetUserEntitlementsAsync(string uuid);
    }
}
