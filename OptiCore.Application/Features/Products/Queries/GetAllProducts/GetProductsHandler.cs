using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Messaging;

namespace OptiCore.Application.Features.Products.Queries.GetAllProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductsDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsHandler(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductsDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            //Query database
            var products = await _productRepository.GetAllAsync();
            //Convert DTO
            var data = _mapper.Map<List<ProductsDTO>>(products);
            //Return DTO
            return data;
        }
    }
}