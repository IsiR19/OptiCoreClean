using MediatR;
using OptiCore.Domain.Leads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Leads.Commands.CreateLead
{
    public class CreateLeadCommand : IRequest<Lead>
    {
        public string LeadCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int StatusID { get; set; }
        public int AssignedUserID { get; set; }
        public int SourceID { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime UpdatedDate { get; set;}
    }
}
