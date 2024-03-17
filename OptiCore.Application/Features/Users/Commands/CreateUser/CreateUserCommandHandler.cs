using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Domain.Users;

namespace OptiCore.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUsersRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreateUserCommand> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator(_userRepository);
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid user", validationResult);

            var data = _mapper.Map<User>(request);

            await _userRepository.CreateAsync(data);

            var response = _mapper.Map<CreateUserCommand>(data);

            return response;
        }
    }
}