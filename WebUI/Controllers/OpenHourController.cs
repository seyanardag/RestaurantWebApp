using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.OpenHourDto;

namespace WebUI.Controllers
{
    public class OpenHourController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenHourController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/OpenHour");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOpenHourDtoUI>>(jsonData);
                return View(values);
            }


            return View();
        }

        [HttpGet]
        public IActionResult CreateOpenHour()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOpenHour(CreateOpenHourDtoUI createOpenHourDtoUI)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOpenHourDtoUI);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44346/api/OpenHour", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View(createOpenHourDtoUI);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteOpenHour(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/OpenHour/{id}");


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOpenHour(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44346/api/OpenHour/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var OpenHour = JsonConvert.DeserializeObject<UpdateOpenHourDtoUI>(json);

                return View(OpenHour);

            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateOpenHour(UpdateOpenHourDtoUI updateOpenHourDtoUI)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateOpenHourDtoUI);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44346/api/OpenHour/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
