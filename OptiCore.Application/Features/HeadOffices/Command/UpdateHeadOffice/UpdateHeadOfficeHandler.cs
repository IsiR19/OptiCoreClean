using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Domain.HeadOffices;

namespace OptiCore.Application.Features.HeadOffices.Command.UpdateHeadOffice
{
    public class UpdateHeadOfficeHandler : IRequestHandler<UpdateHeadOfficeCommand, Unit>
    {
        private readonly IHeadOfficeRepository _headOfficeRepository;
        private readonly IMapper _mapper;

        public UpdateHeadOfficeHandler(IMapper mapper, IHeadOfficeRepository headOfficeRepository)
        {
            _mapper = mapper;
            _headOfficeRepository = headOfficeRepository;
        }

        public async Task<Unit> Handle(UpdateHeadOfficeCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<HeadOffice>(request);

            await _headOfficeRepository.UpdateAsync(data);

            return Unit.Value;
        }
    }
}