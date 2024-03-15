using OptiCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
