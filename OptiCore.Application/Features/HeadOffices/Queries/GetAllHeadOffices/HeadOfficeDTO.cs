using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.CP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices
{
    public class HeadOfficeDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? RegistrationNumber { get; set; }
        public List<ContactDetails>? AddressList { get; set; }

        public virtual ICollection<Cp>? CPList { get; set; }
    }
}
