using OptiCore.Domain.Commissions;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Core;
using OptiCore.Domain.Enums;

namespace OptiCore.Domain.Users
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();

    }
}