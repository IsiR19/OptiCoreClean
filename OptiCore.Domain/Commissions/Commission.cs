using OptiCore.Domain.Core;
using OptiCore.Domain.Users;

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