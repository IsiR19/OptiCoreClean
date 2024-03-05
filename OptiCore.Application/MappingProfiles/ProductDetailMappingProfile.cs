using AutoMapper;
using OptiCore.Application.Features.Products.Queries.GetProduct;
using OptiCore.Domain.Inventory;

namespace OptiCore.Application.MappingProfiles
{
    public class ProductDetailMappingProfile : Profile
    {
        public ProductDetailMappingProfile()
        {
            CreateMap<ProductDetailDTO, Product>().ReverseMap();
        }
    }
}