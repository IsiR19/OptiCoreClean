using OptiCore.Domain.Core;
using OptiCore.Domain.Leads;

namespace OptiCore.Domain.ContactInfromation
{
    public class ContactInformation : AuditEntity
    {
        public int LeadID { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; }

        // Navigation property
        public virtual Lead Lead { get; set; }
    }
}