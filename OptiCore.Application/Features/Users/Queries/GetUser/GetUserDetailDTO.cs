using MediatR;
using OptiCore.Domain.Enums;

namespace OptiCore.Application.Features.Users.Queries.GetUser
{
    public class GetUserDetailDTO : IRequest<GetUserDetailDTO>
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public int? ParentUserId { get; set; }

        //This will list any Channel Partners and Agents under them
        // May need to be extended to show more details , cp name/total sales/sales in progress/commission
        public List<int> SubordinateUserIds { get; set; }

        public int SubordinateCount { get; set; }
        public decimal TotalCommission { get; set; }
    }
}