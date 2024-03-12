using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.HeadOffices.Command.DeleteHeadOffice
{
    public class DeleteHeadOfficeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
