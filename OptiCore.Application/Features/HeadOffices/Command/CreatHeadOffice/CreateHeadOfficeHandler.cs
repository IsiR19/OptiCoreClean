using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Domain.HeadOffices;


namespace OptiCore.Application.Features.HeadOffices.Command.CreatHeadOffice
{
    public class CreateHeadOfficeHandler : IRequestHandler<CreateHeadOfficeCommand, int>
    {
        private readonly IHeadOfficeRepository _headOfficeRepository;
        private readonly IMapper _mapper;

        public CreateHeadOfficeHandler(IHeadOfficeRepository headOfficeRepository,IMapper mapper)
        {
            _headOfficeRepository = headOfficeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateHeadOfficeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateHeadOfficeCommandValidator(_headOfficeRepository);
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Head Office", validationResult);

            var data = _mapper.Map<HeadOffice>(request);

            await _headOfficeRepository.CreateAsync(data);

            return data.Id;
        }
    }
}
