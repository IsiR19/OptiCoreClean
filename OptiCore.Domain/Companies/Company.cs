using OptiCore.Domain.Addresses;
using OptiCore.Domain.Commissions;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Core;
using OptiCore.Domain.Enums;
using System;
using System.Collections.Generic;

namespace OptiCore.Domain.Companies
{
    public class Company : AuditEntity
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public CompanyType CompanyType { get; set; }
        public bool IsActive { get; set; }

        private readonly List<Company> _linkedCompanies = new List<Company>();
        public IReadOnlyList<Company> LinkedCompanies => _linkedCompanies.AsReadOnly();

        private readonly List<ContactDetail> _contactDetails = new List<ContactDetail>();
        public IReadOnlyList<ContactDetail> ContactDetails => _contactDetails.AsReadOnly();

        private readonly List<Address> _addresses = new List<Address>();
        public IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();

        public void AddLinkedCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));
            if (company == this)
                throw new InvalidOperationException("A company cannot link to itself");
            _linkedCompanies.Add(company);
        }

        public void AddContactDetail(ContactDetail contactDetail)
        {
            if (contactDetail == null)
                throw new ArgumentNullException(nameof(contactDetail));
            _contactDetails.Add(contactDetail);
        }

        public void AddAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));
            _addresses.Add(address);
        }
    }
}
