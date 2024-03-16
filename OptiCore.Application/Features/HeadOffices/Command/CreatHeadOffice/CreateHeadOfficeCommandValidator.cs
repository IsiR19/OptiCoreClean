using FluentValidation;
using OptiCore.Application.Abstractions.Contracts.Persistance;

namespace OptiCore.Application.Features.HeadOffices.Command.CreatHeadOffice
{
    public class CreateHeadOfficeCommandValidator : AbstractValidator<CreateHeadOfficeCommand>
    {
        private readonly IHeadOfficeRepository _headOfficeRepository;

        public CreateHeadOfficeCommandValidator(IHeadOfficeRepository headOfficeRepository)
        {
            _headOfficeRepository = headOfficeRepository;
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(h => h.RegistrationNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(p => p)
                .MustAsync(HeadOfficeUnique)
                .WithMessage("Head Office already exists");
        }

        private Task<bool> HeadOfficeUnique(CreateHeadOfficeCommand command, CancellationToken token)
        {
            return _headOfficeRepository.IsHeadOfficeUnique(command.RegistrationNumber);
        }
    }
}