using OptiCore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Contact_Details
{
    public class ContactDetails : AuditEntity
    {
        public int EntityId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string AlternatePhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
