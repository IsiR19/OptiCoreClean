using OptiCore.Domain.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Models.Companies
{
    public class CompanyHierarchyDto
    {
        public int ParentUserId { get; set; }
        public int ChildUserId { get; set; }

        // Navigation properties
        public Company ParentCompany { get; set; }

        public Company ChildCompany { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
