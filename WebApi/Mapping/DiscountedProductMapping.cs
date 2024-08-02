using AutoMapper;
using DtoLayer.CategoryDto;
using DtoLayer.DiscountedProductDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
    public class DiscountedProductMapping : Profile
    {
        public DiscountedProductMapping()
        {
            CreateMap<DiscountedProduct, CreateDiscountedProductDto>().ReverseMap();
            CreateMap<DiscountedProduct, GetDiscountedProductDto>().ReverseMap();
            CreateMap<DiscountedProduct, UpdateDiscountedProductDto>().ReverseMap();
            CreateMap<DiscountedProduct, ResultDiscountedProductDto>().ReverseMap();
        }
    }
}