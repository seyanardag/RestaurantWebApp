using BusinessLayer.Abstract;
using DataAccessLayer.Migrations;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.ContactFormMessageDto;

namespace WebUI.Controllers
{
	public class ContactFormMessageController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactFormMessageController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44346/api/ContactFormMessage");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<List<ResultContactFormMessageDtoUI>>(jsonData);
				var orderedList = result.OrderByDescending(x => x.Date).ToList();
				return View(orderedList);
			}

			return View();
		}

		[HttpGet]
		public IActionResult CreateContactFormMessage()
		{
			//TODO: Buranın View i boş, VC kullandık gibi ama burayı silince sıkıntı çıkıyor???
			return View();
		}
		[HttpPost]
		public IActionResult CreateContactFormMessage(CreateContactFormMessageDtoUI createContactFormMessageDtoUI)
		{
			createContactFormMessageDtoUI.Date = DateTime.Now;
			createContactFormMessageDtoUI.IsRead = false;

			var client = _httpClientFactory.CreateClient();

			var jsonData = JsonConvert.SerializeObject(createContactFormMessageDtoUI);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = client.PostAsync("https://localhost:44346/api/ContactFormMessage", stringContent);

			return RedirectToAction("MainPage", "Home");
		}

        [HttpGet]
        public async Task<IActionResult> MarkAsRead(int id)
        {
          var client = _httpClientFactory.CreateClient();			
			var responseMessage = await client.GetAsync($"https://localhost:44346/api/ContactFormMessage/MarkAsRead/{id}");


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> MarkAsUnRead(int id)
        {
            var client = _httpClientFactory.CreateClient();          
            var responseMessage =await client.GetAsync($"https://localhost:44346/api/ContactFormMessage/MarkAsUnRead/{id}");


            return RedirectToAction("Index");

        }
      
		[HttpGet]
		public async Task<IActionResult> DeleteContactFormMessage(int id)
		{

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/ContactFormMessage/{id}");
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44346/api/ContactFormMessage/{id}");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetContactFormMessageDtoUI>(jsonData);
            return View(result);

        }



    }
}
