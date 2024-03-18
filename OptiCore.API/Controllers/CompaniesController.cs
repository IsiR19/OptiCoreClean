using MediatR;
using Microsoft.AspNetCore.Mvc;
using OptiCore.Application.Features.Companies.Commands.CreateCompany;
using OptiCore.Application.Features.Companies.Commands.UpdateCompany;
using OptiCore.Application.Features.Companies.Queries.GetAllCompanies;
using OptiCore.Application.Features.Companies.Queries.GetCompany;
using OptiCore.Application.Features.Companies.Queries.GetRelatedCompanies;
using OptiCore.Application.Features.Users.Commands.CreateUser;
using OptiCore.Application.Features.Users.Commands.UpdateUser;
using OptiCore.Application.Features.Users.Queries.GetAllUsers;
using OptiCore.Application.Features.Users.Queries.GetUser;
using OptiCore.Application.Models.Companies;

namespace OptiCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        public IMediator _mediator { get; set; }
        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<CompanyDetailDto>> GetAsync(int id)
        {
            var response = await _mediator.Send(new GetCompanyQuery(id));
            return response;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<CompanyDto>>> GetCompaniesAsync()
        {
            var response = await _mediator.Send(new GetAllCompaniesQuery());
            return response;
        }

        [HttpGet("related")]
        public async Task<ActionResult<List<CompanyDto>>> GetRelatedCompaniesAsync(int id)
        {
            var response = await _mediator.Send(new GetRelatedCompaniesQuery(id));
            return response;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateCompanyCommand company)
        {
            var response = await _mediator.Send(company);
            return CreatedAtAction(nameof(GetAsync), new { id = response });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCompanyCommand company)
        {
            await _mediator.Send(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(id);
            return NoContent();
        }
    }
}
