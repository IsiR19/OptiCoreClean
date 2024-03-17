using OptiCore.Domain.Enums;

namespace OptiCore.Application.Features.Users.Queries.GetAllUsers
{
    public class GetUsersDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public decimal TotalCommission { get; set; }
    }
}