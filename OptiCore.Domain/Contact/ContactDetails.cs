using OptiCore.Domain.Companies;

namespace OptiCore.Domain.Contact_Details
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string Type { get; set; }  // e.g., "Email", "Phone"
        public string Value { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
