using MediatR;
using OptiCore.Application.Abstractions.Contracts.Persistance;
using OptiCore.Domain.Contact_Details;
using OptiCore.Domain.Leads;
using OptiCore.Domain.Opportunities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // Convert the command to a domain entity
            var lead = new Lead
            {
                Name = request.Name,
                StatusID = request.StatusID,
                AssignedUserID = request.AssignedUserID,
                SourceID = request.SourceID,
                CreatedDate = request.CreatedDate,
                // Resolve the navigation properties using the repository
                Status = await _leadRepository.GetStatusAsync(request.StatusID),
                Source = await _leadRepository.GetSourceAsync(request.SourceID),
                AssignedUser = await _leadRepository.GetUserAsync(request.AssignedUserID),
                // Initialize the collections or resolve them as necessary
                //ContactInformation = new List<ContactDetails>(),
                Activities = new List<Activity>(),
                Opportunities = new List<Opportunity>(),
                Tasks = new List<Task>()
            };

            // Validation logic could also go here

            // Add the lead to the repository
            await _leadRepository.CreateAsync(lead);
            await _leadRepository.UnitOfWork.SaveChangesAsync();

            return lead;
        }
    }
}
