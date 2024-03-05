using OptiCore.Domain.ContactInfromation;
using OptiCore.Domain.Core;
using OptiCore.Domain.Opportunities;
using OptiCore.Domain.Users;
using System.Diagnostics;

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
        public virtual ICollection<ContactInformation> ContactInformation { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}