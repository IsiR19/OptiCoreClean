using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiCore.Application.Features.HeadOffices.Command.CreatHeadOffice;
using OptiCore.Application.Features.HeadOffices.Command.DeleteHeadOffice;
using OptiCore.Application.Features.HeadOffices.Command.UpdateHeadOffice;
using OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices;
using OptiCore.Application.Features.HeadOffices.Queries.GetHeadOffice;
using OptiCore.Application.Features.Products.Queries.GetAllProducts;

namespace OptiCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadOfficeController : ControllerBase
    {
        public IMediator _mediator { get; }
        public HeadOfficeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<HeadOfficeDTO>> Get(int id)
        {
            var headOffice = await _mediator.Send(new GetHeadOfficeQuery(id));
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
