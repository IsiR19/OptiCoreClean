using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Messaging;
using OptiCore.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Product>(request);

            await _productRepository.CreateAsync(data);

            return data.Id;
        }
    }
}
