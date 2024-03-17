using AutoMapper;
using MediatR;
using Opticore.Infrastructure.Logging;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Features.Users.Commands.CreateUser;
using OptiCore.Application.Models;
using OptiCore.Application.Models.Users;
using OptiCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommand>
    {
        private IUsersRepository _usersRepository;
        private IMapper _mapper;
        private IApplicationLogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUsersRepository usersRepository
            , IMapper mapper
            ,IApplicationLogger<UpdateUserCommandHandler> applicationLogger)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
            _logger = applicationLogger;
        }
        public async Task<UpdateUserCommand> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sending update request for {request.FirstName} {request.LastName}({request.UserId})");

            _logger.LogInformation($"Mapping object {request}");
            var data = _mapper.Map<User>(request);

            _logger.LogInformation($"Mapped data result {data}");
             await _usersRepository.UpdateAsync(data);

            var response = _mapper.Map<UpdateUserCommand>(data);

            _logger.LogInformation($"User {data.FirstName} {data.LastName} saved successfully");
            return response;

        }
    }
}
