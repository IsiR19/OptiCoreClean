using AutoMapper;
using OptiCore.Application.Features.Products.Queries.GetAllProducts;
using OptiCore.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() 
        {
            CreateMap<ProductsDTO,Product>().ReverseMap();
        }
    }
}
