using OptiCore.Domain.Core;
using OptiCore.Domain.Leads;

namespace OptiCore.Domain.Opportunities
{
    public class Opportunity : AuditEntity
    {
        public int LeadID { get; set; }
        public string Name { get; set; }
        public decimal EstimatedValue { get; set; }
        public DateTime CloseDate { get; set; }

        // Navigation property
        public virtual Lead Lead { get; set; }
    }
}