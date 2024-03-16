using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Domain.Leads;
using OptiCore.Domain.Opportunities;

namespace OptiCore.Application.Features.Leads.Commands.CreateLead
{
    public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, Lead>
    {
        private readonly ILeadRepository _leadRepository;

        public CreateLeadCommandHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<Lead> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
           
         throw new NotImplementedException();
        }
    }
}