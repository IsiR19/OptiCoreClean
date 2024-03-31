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
    public class DisabledPolicyService : IPolicyService
    {
        public Task<IPolicy?> GetPolicyByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<IPolicy?> GetPolicyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
