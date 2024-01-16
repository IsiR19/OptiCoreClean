using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Users
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        // Add any other properties specific to a role

        public List<User> Users { get; set; } = new List<User>();
    }
}
