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
        public required bool AddEntitlements { get; set; }
        public required AuthConfiguration AuthConfiguration { get; set; }
    }
}
