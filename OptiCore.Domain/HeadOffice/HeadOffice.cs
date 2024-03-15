using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Core;
using OptiCore.Domain.CP;

namespace OptiCore.Domain.HeadOffices
{
    public class HeadOffice : AuditEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? RegistrationNumber { get; set; }
        public List<ContactDetails>? AddressList { get; set; }

        public virtual ICollection<Cp>? CPList { get; set; }
    }
}