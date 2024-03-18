using OptiCore.Domain.Commissions;
using OptiCore.Domain.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Models.Companies
{
    public class CompanyDetailDto : CompanyDto
    {
        public ICollection<CompanyHierarchy> ChildHierarchies { get; set; }

        public CompanyHierarchy ParentHierarchy { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}
