using OptiCore.Domain.Contact_Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Models.Users
{
    public class UsersDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();
    }
}
