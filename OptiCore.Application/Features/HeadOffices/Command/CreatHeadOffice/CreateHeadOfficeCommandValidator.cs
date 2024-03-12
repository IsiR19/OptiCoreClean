using FluentValidation;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Features.Products.Commands.CreateProduct;


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
        }
        private Task<bool> HeadOfficeUnique(CreateHeadOfficeCommand command, CancellationToken token)
        {
            return _headOfficeRepository.IsHeadOfficeUnique(command.RegistrationNumber);
        }
    }
}
