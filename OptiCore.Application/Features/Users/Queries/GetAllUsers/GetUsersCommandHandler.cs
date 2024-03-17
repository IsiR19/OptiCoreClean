using AutoMapper;
using MediatR;
using Opticore.Infrastructure.Logging;
using OptiCore.Application.Abstractions.Contracts.Persistance;

namespace OptiCore.Application.Features.Users.Queries.GetAllUsers
{
    public class GetUsersCommandHandler : IRequestHandler<GetUsersQuery, List<GetUsersDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        private readonly IApplicationLogger<GetUsersCommandHandler> _logger;

        public GetUsersCommandHandler(IUsersRepository usersRepository, IMapper mapper,IApplicationLogger<GetUsersCommandHandler> logger)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
            _logger = logger;
        }

        public async Task<List<GetUsersDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Fetching list of users");
            var users = _usersRepository.GetAllAsync();
            _logger.LogInformation($"Mapping users list");
            var response = _mapper.Map<List<GetUsersDTO>>(users);
            return response;
        }
    }
}