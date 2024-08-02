using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.ContactDto;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDtoUI>>(jsonData);
                return View(values);
            }


            return View();
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDtoUI createContactDtoUI)
        {
            var client = _httpClientFactory.CreateClient();

			var responseMessage2 = await client.PostAsync("https://localhost:44346/api/Contact/MakeAllContactIsselectedFalse", null);

			if (responseMessage2.IsSuccessStatusCode == false)
				return BadRequest(responseMessage2);

			createContactDtoUI.isSelected = true;
			var jsonData = JsonConvert.SerializeObject(createContactDtoUI);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");


			var responseMessage = await client.PostAsync("https://localhost:44346/api/Contact", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View(createContactDtoUI);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/Contact/{id}");


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44346/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var Contact = JsonConvert.DeserializeObject<UpdateContactDtoUI>(json);

                return View(Contact);

            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDtoUI updateContactDtoUI)
        {
            var client = _httpClientFactory.CreateClient();


			await client.PostAsync($"https://localhost:44346/api/Contact/MakeAllContactIsselectedFalse", null);
			updateContactDtoUI.isSelected = true;

			var jsonData = JsonConvert.SerializeObject(updateContactDtoUI);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44346/api/Contact/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeSelectedContact(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(id);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44346/api/Contact/ChangeSelectedContact", stringContent);

            return RedirectToAction("Index");
        }



	}
}
