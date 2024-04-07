using Auth.Core.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Entitlements
{
    public class UserEntitlement : IUserEntitlement
    {
        public int Id { get; set; }
        public string EntitlementCode { get; set; }
        public bool Disabled { get; set; }
    }
}
