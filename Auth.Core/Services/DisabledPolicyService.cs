using Auth.Core.Interfaces;
using Auth.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Services
{

    //This will be injected when no policy service is injected
    public class DisabledPolicyService : IEntitlementPolicyService
    {
        private string _message = $"No implementation of ${typeof(IEntitlementPolicyService).FullName} was injected";
        public Task<IPolicy?> GetPolicyByCodeAsync(string code)
        {
            throw new NotImplementedException(_message);
        }

        public Task<IPolicy?> GetPolicyByIdAsync(int id)
        {
            throw new NotImplementedException(_message);
        }
    }
    public class DisabledUserEntitlementsService : IUserEntitlementService
    {
        private string _message = $"No implementation of ${typeof(IUserEntitlementService).FullName} was injected";

        public Task AddAsync(string uuid, string entitlementCode)
        {
            throw new NotImplementedException(_message);
        }

        public Task<IEnumerable<IUserEntitlement>> GetAllByUuidAsync(string uuid)
        {
            throw new NotImplementedException(_message);
        }

        public Task RemoveAsync(string uuid, string entitlementCode)
        {
            throw new NotImplementedException(_message);
        }

        public Task ToggleAsync(string uuid, string entitlementCode, bool disabled)
        {
            throw new NotImplementedException(_message);
        }

        public Task ToggleAsync(int id, bool disabled)
        {
            throw new NotImplementedException(_message);
        }
    }
}
