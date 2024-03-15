using OptiCore.Domain.Core;

namespace OptiCore.Domain.Leads
{
    public class LeadStatus : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}