using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Users
{
    public class UserHierarchy
    {
        public int UserHierarchyId { get; set; }
        public int ParentUserId { get; set; }
        public int ChildUserId { get; set; }

        // Navigation properties 
        public User ParentUser { get; set; }
        public User ChildUser { get; set; }
    }
}
