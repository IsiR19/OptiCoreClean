using MediatR;
using OptiCore.Domain.Companies;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Enums;

namespace OptiCore.Application.Features.Users.Queries.GetUser
{
    public class GetUserDetailDTO : IRequest<GetUserDetailDTO>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        //public List<ContactDetails> ContactDetails { get; set; } = new List<ContactDetails>();
    }
}