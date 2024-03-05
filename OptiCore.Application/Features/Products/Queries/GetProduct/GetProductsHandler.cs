using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Messaging;
using OptiCore.Application.Exceptions;

namespace OptiCore.Application.Features.Products.Queries.GetProduct
{
    public class GetProductsHandler : IRequestHandler<GetProductDetailQuery, ProductDetailDTO>
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public GetProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDetailDTO> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            //Query database
            var products = await _productRepository.GetByCodeAsync(request.productCode);
            if (products == null)
                throw new NotFoundException(nameof(products), request.productCode);
            //Convert DTO
            var data = _mapper.Map<ProductDetailDTO>(products);
            //Return DTO
            return data;
        }
    }
}