using Auth.Core;
using Auth.Core.Interfaces.Models;
using OptiCore.Application.Abstractions.Contracts.Identity;
using OptiCore.Domain.Entitlements;
using OptiCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opticore.Identity.Services
{
    public class UserService : IUserService
    {
        public Task<User> GetUser(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IUser?> GetUserByUuidAsync(string uuid)
        {
            var dummyUser = new User() { FirstName = "Matthew", LastName = "Law", Email = "matthew.mcsd@gmail.com" };
            return await Task.FromResult(dummyUser);
        }

        public async Task<IEnumerable<IEntitlement>> GetUserEntitlementsAsync(string uuid)
        {
            var dummyEntitlements = new Entitlement[] { new Entitlement(1, "System Admin", "System Admin", Constants.Entitlements.SystemAdmin) };
            return await Task.FromResult(dummyEntitlements);
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
