using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.FooterInfoDto;

namespace WebUI.Controllers
{
	public class FooterInfoController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FooterInfoController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44346/api/FooterInfo");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFooterInfoDtoUI>>(jsonData);
				return View(values);
			}


			return View();
		}

		[HttpGet]
		public IActionResult CreateFooterInfo()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateFooterInfo(CreateFooterInfoDtoUI createFooterInfoDtoUI)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFooterInfoDtoUI);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:44346/api/FooterInfo", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}


			return View(createFooterInfoDtoUI);
		}


		[HttpGet]
		public async Task<IActionResult> DeleteFooterInfo(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/FooterInfo/{id}");


			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateFooterInfo(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44346/api/FooterInfo/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var FooterInfo = JsonConvert.DeserializeObject<UpdateFooterInfoDtoUI>(json);

				return View(FooterInfo);

			}

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> UpdateFooterInfo(UpdateFooterInfoDtoUI updateFooterInfoDtoUI)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFooterInfoDtoUI);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("https://localhost:44346/api/FooterInfo/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}
	}
}
