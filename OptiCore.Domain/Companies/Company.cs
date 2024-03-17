using OptiCore.Domain.Commissions;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Core;
using OptiCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain.Companies
{
    public class Company : AuditEntity
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public List<ContactDetails> ContactDetails { get; set; }
        public CompanyType CompanyType { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties for EF Core
        public ICollection<CompanyHierarchy> ChildHierarchies { get; set; }

        public CompanyHierarchy ParentHierarchy { get; set; }
        public ICollection<Commission> Commissions { get; set; }


    }
}
