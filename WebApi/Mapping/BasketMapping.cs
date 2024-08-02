using AutoMapper;
using DtoLayer.BasketDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, CreateBasketDto>().ReverseMap();
            CreateMap<Basket, UpdateBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
            CreateMap<Basket, GetBasketDto>().ReverseMap();
        }
    }
}
