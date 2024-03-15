using OptiCore.Domain.Core;
using OptiCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Commissions
{
    public class Commission : AuditEntity
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public int Level { get; set; }

        // Navigation property for EF Core
        public User User { get; set; }
    }
}
