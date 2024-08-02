using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using WebUI.Dtos.SocialMediaDto;

namespace WebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/SocialMedia");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDtoUI>>(jsonData);               
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDtoUI createSocialMediaDtoUI)
        {
            createSocialMediaDtoUI.IsActive = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDtoUI);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesssage = await client.PostAsync("https://localhost:44346/api/SocialMedia", stringContent);

            if (responseMesssage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createSocialMediaDtoUI);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/SocialMedia/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44346/api/SocialMedia/{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData =await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSocialMediaDtoUI>(jsonData);
                return View(value);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDtoUI updateSocialMediaDtoUI)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDtoUI);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PutAsync("https://localhost:44346/api/SocialMedia/", content);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(updateSocialMediaDtoUI);
        }

    }
}
