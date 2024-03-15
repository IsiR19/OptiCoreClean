using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Identity;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Users.Queries.GetUser
{
    public class GetUserCommandHandler : IRequestHandler<GetUserDetailQuery, GetUserDetailDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public GetUserCommandHandler(IUsersRepository usersRepository, IMapper mapper)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<GetUserDetailDTO> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetByIdAsync(request.id);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.id);
            }

            var data = _mapper.Map<GetUserDetailDTO>(user);

            return data;
        }
    }
}


