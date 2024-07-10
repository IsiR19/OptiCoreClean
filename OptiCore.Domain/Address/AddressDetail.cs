using OptiCore.Domain.Companies;

namespace OptiCore.Domain.Addresses
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
