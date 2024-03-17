using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Models.Requests
{
    public class EntitlementValidationRequest
    {

        /// <summary>
        /// The entitlements to validate against
        /// </summary>
        public required IEnumerable<string> Entitlements { get; init; }
    }
}
