using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DependencyInjection.Models
{
    public class EntitlementsDependencyInjectionConfiguration
    {
        public Type? UserEntitlementsServiceType { get; set; }
        public Func<IServiceProvider, object>? UserEntitlementsServiceFactory { get; set; }
        public Type? EntitlementPolicyServiceType { get; set; }
        public Func<IServiceProvider, object>? EntitlementPolicyServiceFactory { get; set; }
    }
}
