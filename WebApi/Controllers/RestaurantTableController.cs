using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ProductDto;
using DtoLayer.RestaurantTableDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RestaurantTableController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IRestaurantTableService _restaurantTableService;

		public RestaurantTableController(IMapper mapper, IRestaurantTableService restaurantTableService)
		{
			_mapper = mapper;
			_restaurantTableService = restaurantTableService;
		}

		[HttpGet]
		public IActionResult GetRestaurantTableList() 
		{
			var values = _restaurantTableService.TGetAll();
			var result = _mapper.Map<List<ResultRestaurantTableDto>>(values);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateRestaurantTable(CreateRestaurantTableDto createRestaurantTableDto)
		{
			var value = _mapper.Map<RestaurantTable>(createRestaurantTableDto);
			_restaurantTableService.TAdd(value);
			return Ok("RestaurantTable oluşturma başarılı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteRestaurantTable(int id)
		{
			_restaurantTableService.TDelete(_restaurantTableService.TGetById(id));

			return Ok("RestaurantTable silme başarılı");
		}

		[HttpGet("{id}")]
		public IActionResult GetRestaurantTableById(int id)
		{
			var value = _restaurantTableService.TGetById(id);
			var result = _mapper.Map<GetRestaurantTableDto>(value);
			return Ok(result);
		}

	
		[HttpPut]
		public IActionResult UpdateRestaurantTable (UpdateRestaurantTableDto updateRestaurantTableDto)
		{
			var value = _mapper.Map<RestaurantTable>(updateRestaurantTableDto);
			_restaurantTableService.TUpdate(value);
			return Ok("RestaurantTable güncelleme başarılı");
		}


		[HttpGet("GetRestaurantTableCount")]
		public IActionResult GetRestaurantTableCount()
		{
			int result = _restaurantTableService.TGetAll().Count();
			return Ok(result);
		}

	

	}
}
