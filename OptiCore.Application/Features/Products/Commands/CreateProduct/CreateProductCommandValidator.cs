using FluentValidation;
using OptiCore.Application.Abstractions.Messaging;

namespace OptiCore.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private IProductRepository _productRepository;

        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(p => p)
                .MustAsync(ProductNameUnique)
                .WithMessage("Product already exists");
        }

        private Task<bool> ProductNameUnique(CreateProductCommand command, CancellationToken token)
        {
            return _productRepository.IsProductUnique(command.Name);
        }
    }
}