using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Models;

namespace Ecommerce.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
