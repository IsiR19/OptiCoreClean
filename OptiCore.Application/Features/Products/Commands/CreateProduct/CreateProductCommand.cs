using MediatR;
using OptiCore.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Products.Commands.CreateProduct
{
    public  class CreateProductCommand : IRequest<int>
    {
        public int ProductCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        // Add any other properties specific to a product
        public int SupplierId { get; set; }
    }
}
