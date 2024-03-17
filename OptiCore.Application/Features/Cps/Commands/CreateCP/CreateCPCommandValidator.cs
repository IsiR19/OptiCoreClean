using FluentValidation;
using OptiCore.Application.Abstractions.Contracts.Persistance;

namespace OptiCore.Application.Features.Cps.Commands.CreateCP
{
    public class CreateCPCommandValidator : AbstractValidator<CreateCPCommand>
    {
        private readonly ICpRepository _cpRepository;
        private readonly ICpRepository _headOfficeRepository;

        public CreateCPCommandValidator(ICpRepository cpRepository)
        {
            _cpRepository = cpRepository;

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            //RuleFor(p => p)
            //    .MustAsync(CPUnique)
            //    .WithMessage("Cp already exists");

            //RuleFor(p => p)
            //   .MustAsync(IsValidHeadOffice)
            //   .WithMessage("Head Office does not exist");
        }

        private Task<bool> CPUnique(CreateCPCommand command, CancellationToken token)
        {
            return _cpRepository.IsCPUnique(command.Name);
        }

        private async Task<bool> IsValidHeadOffice(CreateCPCommand command, CancellationToken token)
        {
            var headOffice = await _headOfficeRepository.GetByIdAsync(command.HeadOfficeId);
            if (headOffice == null)
            {
                return false;
            }

            return true;
        }
    }
}