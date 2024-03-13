using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Features.Cps.Commands.CreateCP;
using OptiCore.Domain.CP;
using OptiCore.Domain.HeadOffices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Cps.Commands.UpdateCP
{
    public class UpdateCPCommandHandler :IRequestHandler<UpdateCPCommand,Unit>
    {
        private readonly ICpRepository _cpRepository;
        private readonly IMapper _mapper;

        public UpdateCPCommandHandler(ICpRepository cpRepository,IMapper mapper)
        {
            _cpRepository = cpRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCPCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Cp>(request);

            await _cpRepository.UpdateAsync(data);

            return Unit.Value;
        }
    }
}
