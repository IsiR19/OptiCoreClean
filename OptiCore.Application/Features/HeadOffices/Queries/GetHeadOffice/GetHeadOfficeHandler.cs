using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices;

namespace OptiCore.Application.Features.HeadOffices.Queries.GetHeadOffice
{
    public class GetHeadOfficeHandler : IRequestHandler<GetHeadOfficeQuery, HeadOfficeDTO>
    {
        private readonly IHeadOfficeRepository _headOfficeRepository;
        private readonly IMapper _mapper;

        public GetHeadOfficeHandler(IHeadOfficeRepository headOfficeRepository, IMapper mapper)
        {
            _headOfficeRepository = headOfficeRepository;
            _mapper = mapper;
        }

        public async Task<HeadOfficeDTO> Handle(GetHeadOfficeQuery request, CancellationToken cancellationToken)
        {
            //Query database
            var headoffice = await _headOfficeRepository.GetByIdAsync(request.id);
            if (headoffice == null)
                throw new NotFoundException(nameof(headoffice), request.id);
            //Convert DTO
            var data = _mapper.Map<HeadOfficeDTO>(headoffice);
            //Return DTO
            return data;
        }
    }
}