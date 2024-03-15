using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Cps.Commands.DeleteCP
{
    public class DeleteCPCommand: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
