using AutoMapper;
using DtoLayer.OrderDetailDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
	public class OrderDetailMapping : Profile
	{
        public OrderDetailMapping()
        {
            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailDto>().ReverseMap();
        }
    }
}
