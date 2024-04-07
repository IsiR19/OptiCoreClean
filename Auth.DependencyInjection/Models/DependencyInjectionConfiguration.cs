using Auth.Core.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DependencyInjection.Models
{
    public class DependencyInjectionConfiguration
    {
        #region Public Properties

        public required bool AddEntitlements { get; set; }
        public required AuthConfiguration AuthConfiguration { get; set; }
        public required UserServiceDependencyInjectionConfiguration UserServiceConfiguration {  get; set; }
        public Type? EntitlementPolicyServiceType { get; set; }    

        #endregion Public Properties
    }
}
