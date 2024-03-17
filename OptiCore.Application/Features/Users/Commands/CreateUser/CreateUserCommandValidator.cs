using FluentValidation;
using OptiCore.Application.Abstractions.Contracts.Persistance;

namespace OptiCore.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private IUsersRepository _usersRepository;

        public CreateUserCommandValidator(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(u => u.LastName)
           .NotEmpty()
           .WithMessage("{PropertyName} is required");

            RuleFor(p => p.Email)
            .NotNull()
            .WithMessage("Email address is required.");

            // Rule to ensure the email is a valid email address
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Email address is not valid.");
        }
    }
}