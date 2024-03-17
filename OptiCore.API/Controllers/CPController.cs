using MediatR;
using Microsoft.AspNetCore.Mvc;
using OptiCore.Application.Features.Cps.Commands.CreateCP;
using OptiCore.Application.Features.Cps.Commands.DeleteCP;
using OptiCore.Application.Features.Cps.Queries.GetCPById;
using Auth.Middleware.Attributes;

namespace OptiCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var cp = await _mediator.Send(new GetCPQuery(id));
            return cp;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateCPCommand cp)
        {
            var response = await _mediator.Send(cp);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateCPCommand cp)
        {
            await _mediator.Send(cp);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCPCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}