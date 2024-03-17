namespace OptiCore.Domain.Companies
{
    public class CompanyHierarchy
    {
        public int UserHierarchyId { get; set; }
        public int ParentUserId { get; set; }
        public int ChildUserId { get; set; }

        // Navigation properties
        public Company ParentCompany { get; set; }

        public Company ChildCompany { get; set; }
    }
}