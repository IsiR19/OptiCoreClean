using OptiCore.Domain.Core;
using OptiCore.Domain.Opportunities;
using OptiCore.Domain.Users;

namespace OptiCore.Domain.Leads
{
    public class Lead : AuditEntity
    {
        public string Name { get; set; } = string.Empty;
        public int StatusID { get; set; }
        public int AssignedUserID { get; set; }
        public int SourceID { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation properties
        public virtual LeadStatus Status { get; set; }

        public virtual LeadSource Source { get; set; }
        public virtual User AssignedUser { get; set; }
        //public virtual I<Contact_Details> ContactInformation { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}