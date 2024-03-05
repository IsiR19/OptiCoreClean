using OptiCore.Domain.Core;
using OptiCore.Domain.CP;

namespace OptiCore.Domain.HeadOffices
{
    public class HeadOffice : AuditEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

        // Navigation property to related CPs
        public virtual ICollection<Cp> CPs { get; set; }
    }
}