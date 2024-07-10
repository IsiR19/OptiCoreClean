using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiCore.Application.Features.Companies.Commands.CreateCompany;
using OptiCore.Application.Features.Companies.Commands.UpdateCompany;
using OptiCore.Application.Features.Companies.Queries.GetAllCompanies;
using OptiCore.Application.Features.Companies.Queries.GetCompany;
using OptiCore.Application.Features.Companies.Queries.GetRelatedCompanies;
using OptiCore.Application.Models.Companies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OptiCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetailDto>> GetAsync(int id)
        {
            var query = new GetCompanyQuery(id);
            var response = await _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<CompanyDto>>> GetCompaniesAsync()
        {
            var query = new GetAllCompaniesQuery();
            var response = await _mediator.Send(query);

            return response;
        }

        [HttpGet("related")]
        public async Task<ActionResult<List<CompanyDto>>> GetRelatedCompaniesAsync(int id)
        {
            var query = new GetRelatedCompaniesQuery(id);
            var response = await _mediator.Send(query);

            return response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CompanyDetailDto>> Post(CreateCompanyCommand command)
        {
            var response = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetAsync), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, UpdateCompanyCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            //await _mediator.Send(new DeleteCompanyCommand(id));

            return NoContent();
        }
    }
}
