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
        public string Policy { get; init; }
        public AuthorizeAttribute() : base(typeof(AuthorizationFilter))
        {
            Policy = "NONE";
            Arguments = new[] { Policy };
        }

        public AuthorizeAttribute(string policy) : base(typeof(AuthorizationFilter))
        {
            Policy = policy;
            Arguments = new[] { Policy };
        }
    }
}
