using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces.Models
{
    public interface IPolicy
    {
        int Id { get; set; }
        string Code { get; set; }   
        string Name { get; set; }
        string Description { get; set; }
        IEnumerable<IEntitlement> Entitlements { get; set; }
    }
}
