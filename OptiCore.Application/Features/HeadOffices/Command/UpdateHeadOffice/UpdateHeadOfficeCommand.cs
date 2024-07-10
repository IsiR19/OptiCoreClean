using MediatR;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.CP;

namespace OptiCore.Application.Features.HeadOffices.Command.UpdateHeadOffice
{
    public class UpdateHeadOfficeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? RegistrationNumber { get; set; }
        //public List<ContactDetails>? ContactDetails { get; set; }

        public virtual ICollection<Cp>? CPList { get; set; }
    }
}