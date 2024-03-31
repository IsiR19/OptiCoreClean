using Auth.Core;
using Auth.Middleware.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Middleware.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public string PolicyOrEntitlement { get; init; }
        public bool IsEntitlement { get; init; }
        public AuthorizeAttribute() : base(typeof(AuthorizationFilter))
        {
            PolicyOrEntitlement = "NONE";
            Arguments = new object[] { PolicyOrEntitlement, IsEntitlement };
        }

        public AuthorizeAttribute(string policy, bool isEntitlement = false) : base(typeof(AuthorizationFilter))
        {
            PolicyOrEntitlement = policy;
            IsEntitlement = isEntitlement;
            Arguments = new object[] { PolicyOrEntitlement, isEntitlement };
        }
    }
}
