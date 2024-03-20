using OptiCore.Domain.Core;

namespace OptiCore.Domain.Companies
{
    public class CompanyHierarchy : AuditEntity
    {
        public int ParentUserId { get; set; }
        public int ChildUserId { get; set; }

        // Navigation properties
        public Company ParentCompany { get; set; }

        public Company ChildCompany { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}