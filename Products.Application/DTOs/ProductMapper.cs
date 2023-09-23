using AutoMapper;
using Products.Domain.Entities;

namespace Products.Application.DTOs
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductInsertDTO, Product>();
            CreateMap<Product, ProductGetDTO>();
        }
    }
}
