using BusinessLayer.CustomServices.Abstract;
using BusinessLayer.CustomServices.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.ProductDto;
using WebUI.Dtos.TestimonialDto;

namespace WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileUploadService _uploadService;

        public TestimonialController(IHttpClientFactory httpClientFactory, IFileUploadService uploadService)
        {
            _httpClientFactory = httpClientFactory;
            _uploadService = uploadService;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDtoUI>>(jsonData);
                return View(values);
            }


            return View();
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDtoUI createTestimonialDtoUI)
        {
            createTestimonialDtoUI.ImgUrl = await _uploadService.UploadFileAsync(createTestimonialDtoUI.ImgFile, "images/TestimonialImages");
           

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialDtoUI);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44346/api/Testimonial", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View(createTestimonialDtoUI);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/Testimonial/{id}");

            var json = await responseMessage.Content.ReadAsStringAsync();
            var testimonial = JsonConvert.DeserializeObject<Testimonial>(json);

            await _uploadService.DeleteFileAsync(testimonial.ImgUrl);
  
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {

            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44346/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var Testimonial = JsonConvert.DeserializeObject<UpdateTestimonialDtoUI>(json);

                return View(Testimonial);

            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDtoUI updateTestimonialDtoUI)
        {
            //resim için işlemler
            if (updateTestimonialDtoUI.ImgFile != null && updateTestimonialDtoUI.ImgFile.Length > 0)
            {
                // Var olan dosya yolunu al
                var existingFilePath = updateTestimonialDtoUI.ImgUrl;

                // Yeni dosyayı yükle ve eski dosyayı sil
                var newFilePath = await _uploadService.UpdateFileAsync(updateTestimonialDtoUI.ImgFile, existingFilePath, "images/TestimonialImages");

                // DTO'yu güncelle
                updateTestimonialDtoUI.ImgUrl = newFilePath;
            }


            //Api işlemleri
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTestimonialDtoUI);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44346/api/Testimonial/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(updateTestimonialDtoUI);
        }
    }
}
