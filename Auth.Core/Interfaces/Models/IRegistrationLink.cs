using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces.Models
{
    public interface IRegistrationLink
    {
        public int CompanyId { get; set; }
        public string Guid { get; set; }
        public string EntitlementPolicy { get; set; }
        public DateTime ExpireAt { get; set; }
        public int UsersLeft { get; set; }
    }
}
