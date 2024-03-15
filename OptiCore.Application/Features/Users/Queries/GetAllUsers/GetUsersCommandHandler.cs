using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;


namespace OptiCore.Application.Features.Users.Queries.GetAllUsers
{
    public class GetUsersCommandHandler : IRequestHandler<GetUsersQuery, List<GetUsersDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public GetUsersCommandHandler(IUsersRepository usersRepository,IMapper mapper)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<List<GetUsersDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var subOrdinates = await _usersRepository.GetRelatedUsersAsync(request.userId);
            var data = _mapper.Map<List<GetUsersDTO>>(subOrdinates);

            return data;
        }
    }
}
