using OptiCore.Domain.Commissions;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Models.Companies
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public List<ContactDetails> ContactDetails { get; set; }
        public CompanyType CompanyType { get; set; }
        public bool IsActive { get; set; }
    }
}
