using OptiCore.Domain.Core;

namespace OptiCore.Domain.Companies
{
    public class CompanyHierarchy : AuditEntity
    {
        public int ParentCompanyId { get; set; }
        public virtual Company ParentCompany { get; set; }

        public int ChildCompanyId { get; set; }
        public virtual Company ChildCompany { get; set; }
    }

}