using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Models.Common
{
    public class DeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
