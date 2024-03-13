using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiCore.Application.Features.Cps.Queries.GetCPById;
using OptiCore.Application.Features.HeadOffices.Command.CreatHeadOffice;
using OptiCore.Application.Features.HeadOffices.Command.DeleteHeadOffice;
using OptiCore.Application.Features.HeadOffices.Command.UpdateHeadOffice;
using OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices;
using OptiCore.Application.Features.HeadOffices.Queries.GetHeadOffice;

namespace OptiCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CPController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CPDTO>> Get(int id)
        {
            var headOffice = await _mediator.Send(new GetCPQuery(id));
            return headOffice;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateHeadOfficeCommand headOffice)
        {
            var response = await _mediator.Send(headOffice);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateHeadOfficeCommand headOffice)
        {
            await _mediator.Send(headOffice);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteHeadOfficeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
