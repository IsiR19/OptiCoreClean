using AutoMapper;
using MediatR;
using OptiCore.Application.Abstractions.Messaging;
using OptiCore.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IMapper mapper,IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Product>(request);

            await _productRepository.UpdateAsync(data);

            return Unit.Value;
        }
    }
}
