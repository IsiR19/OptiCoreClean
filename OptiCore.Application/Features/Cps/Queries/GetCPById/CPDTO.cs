using OptiCore.Domain.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Cps.Queries.GetCPById
{
    public class CPDTO
    {
        public int Id { get; set; }
        public int HeadOfficeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;

        private readonly List<Agent> _agents = new List<Agent>();
    }
}
