using MediatR;
using Microsoft.AspNetCore.Mvc;
using OptiCore.Application.Features.HeadOffices.Command.CreatHeadOffice;
using OptiCore.Application.Features.HeadOffices.Command.DeleteHeadOffice;
using OptiCore.Application.Features.HeadOffices.Command.UpdateHeadOffice;
using OptiCore.Application.Features.HeadOffices.Queries.GetAllHeadOffices;
using OptiCore.Application.Features.HeadOffices.Queries.GetHeadOffice;
using OptiCore.Application.Features.Users.Commands.CreateUser;
using OptiCore.Application.Features.Users.Commands.UpdateUser;
using OptiCore.Application.Features.Users.Queries.GetAllUsers;
using OptiCore.Application.Features.Users.Queries.GetUser;

namespace OptiCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController :ControllerBase
    {
        public IMediator _mediator { get; }
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetUserDetailDTO>> Get(int id)
        {
            var user = await _mediator.Send(new GetUserDetailQuery(id));
            return user;
        }

        [HttpGet("related")]
        public async Task<ActionResult<List<GetUsersDTO>>> GetRelatedUsersAsync(int id)
        {
            var user = await _mediator.Send(new GetUsersQuery(id));
            return user;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateUserCommand user)
        {
            var response = await _mediator.Send(user);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateUserCommand user)
        {
            await _mediator.Send(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}




