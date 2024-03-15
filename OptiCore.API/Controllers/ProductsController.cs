using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiCore.Application.Features.Products.Queries.GetAllProducts;
using OptiCore.Application.Features.Products.Queries.GetProduct;

namespace OptiCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IMediator _mediator { get; }

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductsDTO>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return products;
        }
        

    }
        
}
