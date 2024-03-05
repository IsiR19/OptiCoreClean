using OptiCore.Domain.Agents;
using OptiCore.Domain.HeadOffices;

namespace OptiCore.Domain.CP
{
    public class Cp
    {
        public int CPId { get; set; } // Primary key
        public int HeadOfficeId { get; set; } // Foreign key to HeadOffice
        public string CPName { get; set; }
        // Other properties related to CP

        // Navigation properties
        public virtual HeadOffice HeadOffice { get; set; }

        public virtual ICollection<Agent> Agents { get; set; }
    }
}