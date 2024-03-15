using MediatR;
using MediatR.Pipeline;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Application.Features.HeadOffices.Command.DeleteHeadOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Cps.Commands.DeleteCP
{
    public class DeleteCPCommandHandler : IRequestHandler<DeleteCPCommand,Unit>
    {
        private readonly ICpRepository _cpRepository;

        public DeleteCPCommandHandler(ICpRepository cpRepository)
        {
            _cpRepository = cpRepository;
        }

        public async Task<Unit> Handle(DeleteCPCommand request, CancellationToken cancellationToken)
        {
            //Get Record by Id
            var cp = await _cpRepository.GetByIdAsync(request.Id);
            //Validate Record Exists
            if (cp == null)
                throw new NotFoundException(nameof(cp), request.Id);
            //Remove Record from Database
            await _cpRepository.DeleteAsync(cp);

            return Unit.Value;
        }
    }
}
