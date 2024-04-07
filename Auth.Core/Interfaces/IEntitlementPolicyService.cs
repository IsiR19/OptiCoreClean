using Auth.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces
{
    /// <summary>
    /// This interface will be used to get Entitlement policies
    /// </summary>
    public interface IEntitlementPolicyService
    {
        /// <summary>
        /// Gets the policy by Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<IPolicy?> GetPolicyByCodeAsync(string code);
        /// <summary>
        /// Gets the policy by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IPolicy?> GetPolicyByIdAsync(int id);
    }
}
