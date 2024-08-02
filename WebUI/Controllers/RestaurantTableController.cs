using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;
using System.Text;
using WebUI.Dtos.RestaurantTableDto;

namespace WebUI.Controllers
{
	public class RestaurantTableController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

			public RestaurantTableController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44346/api/RestaurantTable");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var results = JsonConvert.DeserializeObject<List<ResultRestaurantTableDtoUI>>(json);
				return View(results);

			}


			return View();
		}


		[HttpGet]
		public IActionResult CreateRestaurantTable() 
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateRestaurantTable(CreateRestaurantTableDtoUI createRestaurantTableDtoUI) 
		{
			var client = _httpClientFactory.CreateClient();

			var jsonData = JsonConvert.SerializeObject(createRestaurantTableDtoUI);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json" );
			var responseMessage = await client.PostAsync("https://localhost:44346/api/RestaurantTable", content);
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> DeleteRestaurantTable(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/RestaurantTable/{id}");
			
			return RedirectToAction("Index");
		
		}

		[HttpGet]
		public async Task<IActionResult> UpdateRestaurantTable(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage =await client.GetAsync($"https://localhost:44346/api/RestaurantTable/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateRestaurantTableDtoUI>(jsonData);
				return View(value);

			}

			return RedirectToAction("Index");
		}


		[HttpPost]
		public async Task<IActionResult> UpdateRestaurantTable(UpdateRestaurantTableDtoUI updateRestaurantTableDtoUI)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateRestaurantTableDtoUI);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage =await client.PutAsync("https://localhost:44346/api/RestaurantTable", content);

			if(responseMessage.IsSuccessStatusCode)
			{
                return RedirectToAction("Index");
            }
			return View(updateRestaurantTableDtoUI);
        }

		[HttpGet]
		public IActionResult TablesRealtime()
		{
			return View();
		}
	}
}
