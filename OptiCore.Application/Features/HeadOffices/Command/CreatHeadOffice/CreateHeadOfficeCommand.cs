using MediatR;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.CP;

namespace OptiCore.Application.Features.HeadOffices.Command.CreatHeadOffice
{
    public class CreateHeadOfficeCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? RegistrationNumber { get; set; }
        public List<ContactDetails>? AddressList { get; set; }

        public virtual ICollection<Cp>? CPList { get; set; }
    }
}