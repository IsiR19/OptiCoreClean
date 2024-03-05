using MediatR;
using OptiCore.Application.Abstractions.Messaging;
using OptiCore.Application.Exceptions;

namespace OptiCore.Application.Features.Products.Commands.DeleteProduct
{
    public class DeletCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public DeletCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            //Get Record by Id
            var product = await _productRepository.GetByIdAsync(request.Id);
            //Validate Record Exists
            if (product == null)
                throw new NotFoundException(nameof(product), request.Id);
            //Remove Record from Database
            await _productRepository.DeleteAsync(product);

            return Unit.Value;
        }
    }
}