using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<HeadOfficeDTO> GetHeadOffice(int id)
        {
            var headOffice = await _mediator.Send(new GetHeadOfficeQuery(id));
            return headOffice;
        }
    }
}
