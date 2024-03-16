using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Domain.CP;

namespace OptiCore.Application.Features.Cps.Commands.CreateCP
{
    public class CreateCPCommandHandler : IRequestHandler<CreateCPCommand, int>
    {
        private readonly ICpRepository _cpRepository;
        private readonly IMapper _mapper;

        public CreateCPCommandHandler(ICpRepository cpRepository, IMapper mapper)
        {
            _cpRepository = cpRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCPCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCPCommandValidator(_cpRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid data supplied for CP", validationResult);

            var data = _mapper.Map<Cp>(request);

            await _cpRepository.CreateAsync(data);

            return data.Id;
        }
    }
}