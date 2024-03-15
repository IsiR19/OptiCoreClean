using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;


namespace OptiCore.Application.Features.Cps.Queries.GetCPById
{
    public class GetCPByIDHandler : IRequestHandler<GetCPQuery,CPDTO>
    {
      private readonly IMapper _mapper;
        private readonly ICpRepository _cpRepository;

        public GetCPByIDHandler(  IMapper mapper, ICpRepository cpRepository)
        {
            _cpRepository = cpRepository;
            _mapper = mapper;
        }

        public async Task<CPDTO> Handle(GetCPQuery request, CancellationToken cancellationToken)
        {
            //Query database
            var cp = await _cpRepository.GetByIdAsync(request.id);
            if (cp == null)
                throw new NotFoundException(nameof(cp), request.id);
            //Convert DTO
            var data = _mapper.Map<CPDTO>(cp);
            //Return DTO
            return data;
        }
    }
}
