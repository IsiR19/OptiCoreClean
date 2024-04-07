using Auth.Core;
using Auth.Core.Interfaces;
using Auth.Core.Interfaces.Models;
using OptiCore.Domain.Entitlements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opticore.Identity.Services
{
    public class UserEntitlementsService : IUserEntitlementService
    {
        public Task AddAsync(string uuid, string entitlementCode)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IUserEntitlement>> GetAllByUuidAsync(string uuid)
        {
            return new UserEntitlement[] { new UserEntitlement() { EntitlementCode = Constants.Entitlements.SystemAdmin } };
        }

        public Task RemoveAsync(string uuid, string entitlementCode)
        {
            throw new NotImplementedException();
        }

        public Task ToggleAsync(string uuid, string entitlementCode, bool disabled)
        {
            throw new NotImplementedException();
        }

        public Task ToggleAsync(int id, bool disabled)
        {
            throw new NotImplementedException();
        }
    }
}
