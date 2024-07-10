using Auth.Core.Interfaces.Models;
using OptiCore.Domain.Commissions;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Core;
using OptiCore.Domain.Enums;

namespace OptiCore.Domain.Users
{
    public class User : BaseEntity, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public string UUID { get; set; }
        public string Name { get => $"{FirstName} {LastName}"; set { } }
    }
}