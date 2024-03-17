using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;

namespace OptiCore.Application.Features.Cps.Commands.DeleteCP
{
    public class DeleteCPCommandHandler : IRequestHandler<DeleteCPCommand, Unit>
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