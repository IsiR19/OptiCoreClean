using FluentValidation;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Application.Features.HeadOffices.Command.CreatHeadOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Cps.Commands.CreateCP
{
    public class CreateCPCommandValidator : AbstractValidator<UpdateCPCommand>
    {
        private readonly ICpRepository _cpRepository;
        public CreateCPCommandValidator(ICpRepository cpRepository)
        {
            _cpRepository = cpRepository;

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");


            RuleFor(p => p)
                .MustAsync(CPUnique)
                .WithMessage("Head Office already exists");
        }
        private Task<bool> CPUnique(UpdateCPCommand command, CancellationToken token)
        {
            return _cpRepository.IsCPUnique(command.Name);
        }
    }


    }
}
