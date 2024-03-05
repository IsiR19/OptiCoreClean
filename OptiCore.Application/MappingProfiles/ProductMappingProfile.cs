using AutoMapper;
using OptiCore.Application.Features.Products.Queries.GetAllProducts;
using OptiCore.Domain.Inventory;

namespace OptiCore.Application.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductsDTO, Product>().ReverseMap();
        }
    }
}