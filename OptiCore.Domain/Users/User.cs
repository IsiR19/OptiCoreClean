using OptiCore.Domain.Commissions;
using OptiCore.Domain.Core;
using OptiCore.Domain.Enums;

namespace OptiCore.Domain.Users
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType Role { get; set; }

        // Navigation properties for EF Core
        public ICollection<UserHierarchy> ChildHierarchies { get; set; }
        public UserHierarchy ParentHierarchy { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}