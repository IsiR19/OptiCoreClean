using AutoMapper;
using OptiCore.Application.Features.Products.Queries.GetProduct;
using OptiCore.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.MappingProfiles
{
    public class ProductDetailMappingProfile : Profile
    {
        public ProductDetailMappingProfile()
        {
            CreateMap<ProductDetailDTO,Product>().ReverseMap();
        }
    }
}
