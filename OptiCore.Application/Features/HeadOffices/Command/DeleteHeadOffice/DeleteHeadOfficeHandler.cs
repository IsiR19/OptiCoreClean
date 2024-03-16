using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;

namespace OptiCore.Application.Features.HeadOffices.Command.DeleteHeadOffice
{
    public class DeleteHeadOfficeHandler : IRequestHandler<DeleteHeadOfficeCommand, Unit>
    {
        private readonly IHeadOfficeRepository _headOfficeRepository;

        public DeleteHeadOfficeHandler(IHeadOfficeRepository headOfficeRepository)
        {
            _headOfficeRepository = headOfficeRepository;
        }

        public async Task<Unit> Handle(DeleteHeadOfficeCommand request, CancellationToken cancellationToken)
        {
            //Get Record by Id
            var headOffice = await _headOfficeRepository.GetByIdAsync(request.Id);
            //Validate Record Exists
            if (headOffice == null)
                throw new NotFoundException(nameof(headOffice), request.Id);
            //Remove Record from Database
            await _headOfficeRepository.DeleteAsync(headOffice);

            return Unit.Value;
        }
    }
}