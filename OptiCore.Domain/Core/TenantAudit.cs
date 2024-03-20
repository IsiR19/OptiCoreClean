using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Core
{
    public class TenantAudit
    {
            public int UserId { get; set; }
            public DateTime? UpdatedOn { get; set; }
            public string UpdatedBy { get; set; } = string.Empty;
        
    }
}
