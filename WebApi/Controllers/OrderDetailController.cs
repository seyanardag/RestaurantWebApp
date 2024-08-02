using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.OrderDetailDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailController : ControllerBase
	{
		private readonly IOrderDetailService _OrderDetailService;

		private readonly IMapper _mapper;

		public OrderDetailController(IOrderDetailService OrderDetailService, IMapper mapper)
		{
			_OrderDetailService = OrderDetailService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetOrderDetailList()
		{
			var values = _OrderDetailService.TGetAll();
			var result = _mapper.Map<List<ResultOrderDetailDto>>(values);

			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateOrderDetail(CreateOrderDetailDto createOrderDetailDto)
		{
			OrderDetail value = _mapper.Map<OrderDetail>(createOrderDetailDto);
			_OrderDetailService.TAdd(value);

			return Ok("OrderDetail oluşturma başarılı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteOrderDetail(int id)
		{
			var valueToDel = _OrderDetailService.TGetById(id);
			_OrderDetailService.TDelete(valueToDel);

			return Ok("OrderDetail silme başarılı");
		}
		[HttpPut]
		public IActionResult UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto)
		{
			OrderDetail valueToUpdate = _mapper.Map<OrderDetail>(updateOrderDetailDto);
			_OrderDetailService.TUpdate(valueToUpdate);

			return Ok("OrderDetail güncelleme başarılı");
		}
		[HttpGet("{id}")]
		public IActionResult GetOrderDetail(int id)
		{

			OrderDetail value = _mapper.Map<OrderDetail>(_OrderDetailService.TGetById(id));

			return Ok(value);
		}
	}
}
