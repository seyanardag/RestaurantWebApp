using BusinessLayer.CustomServices.Abstract;
using BusinessLayer.CustomServices.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.AboutDto;
using WebUI.Dtos.ProductDto;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileUploadService _uploadService;

        public AboutController(IHttpClientFactory httpClientFactory, IFileUploadService uploadService)
        {
            _httpClientFactory = httpClientFactory;
            _uploadService = uploadService;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/About");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDtoUI>>(jsonData);
             
                return View(values);
            }


            return View();
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }  
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDtoUI createAboutDtoUI)
        {
            //TODO:Image için kodlar düzenlenecek
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        // Dosya yükleme işlemi
            //        string uniqueFileName = null;
            //        if (createAboutDtoUI.ImgUrl != null && createAboutDtoUI.ImgUrl.Length > 0)
            //        {
            //            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/aboutImages/");
            //            uniqueFileName = Guid.NewGuid().ToString() + "_" + createAboutDtoUI.ImgUrl.FileName;
            //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //            createAboutDtoUI.ImgUrl.CopyTo(new FileStream(filePath, FileMode.Create));
            //        }

            //        // Diğer veri işleme işlemleri
            //        // Örneğin, veritabanına kaydetme




            //        return RedirectToAction("Index");
            //    }
            //    catch (Exception ex)
            //    {
            //        // Hata yönetimi
            //        ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
            //        return View(createAboutDtoUI);
            //    }
            //}

            createAboutDtoUI.ImgUrl = await _uploadService.UploadFileAsync(createAboutDtoUI.ImgFile, "images/AboutImages");


			createAboutDtoUI.isSelected = false;

			var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutDtoUI);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44346/api/About", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View(createAboutDtoUI);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/About/{id}");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var about = JsonConvert.DeserializeObject<About>(jsonData);

            await _uploadService.DeleteFileAsync(about.ImgUrl);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44346/api/About/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var about = JsonConvert.DeserializeObject<UpdateAboutDtoUI>(json);


                return View(about);

            }

            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDtoUI updateAboutDtoUI)
        {

            //resim için işlemler
            if (updateAboutDtoUI.ImgFile != null && updateAboutDtoUI.ImgFile.Length > 0)
            {
                // Var olan dosya yolunu al
                var existingFilePath = updateAboutDtoUI.ImgUrl;

                // Yeni dosyayı yükle ve eski dosyayı sil
                var newFilePath = await _uploadService.UpdateFileAsync(updateAboutDtoUI.ImgFile, existingFilePath, "images/aboutImages");

                // DTO'yu güncelle
                updateAboutDtoUI.ImgUrl = newFilePath;
            }


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDtoUI);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44346/api/About/", stringContent);

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeSelectedAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();

			var jsonData = JsonConvert.SerializeObject(id);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage =  await client.PostAsync("https://localhost:44346/api/About/changeSelectedAbout/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}


            return BadRequest();
        }


    }
}
