using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DependencyInjection.Models
{
    public class UserServiceDependencyInjectionConfiguration
    {
        public required Type ImplementationType { get; set; }
        public Func<IServiceProvider, object>? ImplementationFactory { get; set; }
    }
}
