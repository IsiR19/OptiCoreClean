using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Domain.CP;
using OptiCore.Domain.HeadOffices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Cps.Commands.CreateCP
{
    public class CreateCPCommandHandler : IRequestHandler<UpdateCPCommand, int>
    {
        private readonly ICpRepository _cpRepository;
        private readonly IMapper _mapper;

        public CreateCPCommandHandler(ICpRepository cpRepository,IMapper mapper)
        {
            _cpRepository = cpRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateCPCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCPCommandValidator(_cpRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Head Office", validationResult);

            var data = _mapper.Map<Cp>(request);

            await _cpRepository.CreateAsync(data);

            return data.Id;
        }
    }
}
