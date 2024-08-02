using BusinessLayer.CustomServices.Abstract;
using BusinessLayer.CustomServices.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.DiscountedProductDto;


namespace WebUI.Controllers
{
	public class DiscountedProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IFileUploadService _uploadService;

        public DiscountedProductController(IHttpClientFactory httpClientFactory, IFileUploadService uploadService)
        {
            _httpClientFactory = httpClientFactory;
            _uploadService = uploadService;
        }

        public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44346/api/DiscountedProduct");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDiscountedProductDtoUI>>(jsonData);
				return View(values);
			}


			return View();
		}

		[HttpGet]
		public IActionResult CreateDiscountedProduct()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateDiscountedProduct(CreateDiscountedProductDtoUI createDiscountedProductDtoUI)
		{
            createDiscountedProductDtoUI.ImgUrl = await _uploadService.UploadFileAsync(createDiscountedProductDtoUI.ImgFile, "images/DiscountedProductsImages");
           

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createDiscountedProductDtoUI);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("https://localhost:44346/api/DiscountedProduct", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}


			return View(createDiscountedProductDtoUI);
		}


		[HttpGet]
		public async Task<IActionResult> DeleteDiscountedProduct(int id)
		{


			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/DiscountedProduct/{id}");
			
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var discountedProduct = JsonConvert.DeserializeObject<DiscountedProduct>(jsonData);

            await _uploadService.DeleteFileAsync(discountedProduct.ImgUrl);

            return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateDiscountedProduct(int id)
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44346/api/DiscountedProduct/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var DiscountedProduct = JsonConvert.DeserializeObject<UpdateDiscountedProductDtoUI>(json);

				return View(DiscountedProduct);

			}

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> UpdateDiscountedProduct(UpdateDiscountedProductDtoUI updateDiscountedProductDtoUI)
		{

			//resim için işlemler
            if (updateDiscountedProductDtoUI.ImgFile != null && updateDiscountedProductDtoUI.ImgFile.Length > 0)
            {
                // Var olan dosya yolunu al
                var existingFilePath = updateDiscountedProductDtoUI.ImgUrl;

                // Yeni dosyayı yükle ve eski dosyayı sil
                var newFilePath = await _uploadService.UpdateFileAsync(updateDiscountedProductDtoUI.ImgFile, existingFilePath, "images/DiscountedProductsImages");

                // DTO'yu güncelle
                updateDiscountedProductDtoUI.ImgUrl = newFilePath;
            }

            
            //Api işlemleri
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateDiscountedProductDtoUI);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync("https://localhost:44346/api/DiscountedProduct/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}
	}
}
