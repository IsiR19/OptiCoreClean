using MediatR;
using Opticore.Infrastructure.Logging;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Exceptions;
using OptiCore.Application.Features.Products.Commands.DeleteProduct;
using OptiCore.Application.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteCommand,Unit>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IApplicationLogger<DeleteUserCommandHandler> _logger;
        public DeleteUserCommandHandler(IUsersRepository usersRepository,IApplicationLogger<DeleteUserCommandHandler> logger)
        {
            _logger = logger;
            _usersRepository = usersRepository;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            //Get Record by Id
            _logger.LogInformation($"Checking if user exists for {request.Id}");
            var user = await _usersRepository.GetByIdAsync(request.Id);
            //Validate Record Exists
            if (user == null)
            {
                _logger.LogWarning($"User : {request.Id} does not exist");
                throw new NotFoundException(nameof(user), request.Id);
            }

            //Remove Record from Database
            await _usersRepository.DeleteAsync(user);
            _logger.LogInformation($"User : {request.Id} removed successfully");
            return Unit.Value;
        }
    }
}
