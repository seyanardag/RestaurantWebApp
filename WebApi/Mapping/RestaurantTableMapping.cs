using AutoMapper;
using DtoLayer.RestaurantTableDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
	public class RestaurantTableMapping : Profile
	{
        public RestaurantTableMapping()
        {
            CreateMap<RestaurantTable, ResultRestaurantTableDto>().ReverseMap();
            CreateMap<RestaurantTable, GetRestaurantTableDto>().ReverseMap();
            CreateMap<RestaurantTable, UpdateRestaurantTableDto>().ReverseMap();
            CreateMap<RestaurantTable, CreateRestaurantTableDto>().ReverseMap();
        }
    }
}
