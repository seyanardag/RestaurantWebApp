using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.OpenHourDto;
using DtoLayer.OrderDetailDto;
using DtoLayer.OrderDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrderController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetOrderList()
		{
			

			List<Order> orders = _orderService.TGetAll();
			var values = _mapper.Map<List<ResultOrderDto>>(orders);

			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateOrder (CreateOrderDto createOrderDto)
		{
			var order = _mapper.Map<Order>(createOrderDto);
			_orderService.TAdd(order);

			return Ok("Order başarıyla eklendi");
		}

		[HttpDelete]
		public IActionResult DeleteOrder(int id)
		{
			Order order = _orderService.TGetById(id);
			_orderService.TDelete(order);

			return Ok("Order silme başarılı");
		}

		[HttpGet("{id}")]
		public IActionResult GetOrder (int id)
		{
			Order order = _orderService.TGetById(id);
			var value = _mapper.Map<GetOrderDto>(order);

			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto)
		{
			Order order = _mapper.Map<Order>(updateOrderDto);
			_orderService.TUpdate(order);


			return Ok("Order güncelleme başarılı");
		}

		[HttpGet("GetTotalOrderCount")]

		public IActionResult GetTotalOrderCount()
		{
			return Ok(_orderService.TGetTotalOrderCount());
		}
			
		[HttpGet("ActiveOrderCount")]	

		public IActionResult ActiveOrderCount()
		{
			return Ok(_orderService.TActiveOrderCount());
		}	
		[HttpGet("LastOrderPrice")]	

		public IActionResult LastOrderPrice()
		{
			return Ok(_orderService.TLastOrderPrice());
		}
		[HttpGet("EndorsementToday")]

		public IActionResult EndorsementToday()
		{
			return Ok(_orderService.TEndorsementToday());
		}

	}
}
