using BusinessLayer.CustomServices.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Text;
using WebUI.Dtos.CategoryDto;
using WebUI.Dtos.ProductDto;



namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileUploadService _fileUploadService;

        public ProductController(IHttpClientFactory httpClientFactory, IFileUploadService fileUploadService)
        {
            _httpClientFactory = httpClientFactory;
            _fileUploadService = fileUploadService;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/Product/GetProductsWithCategories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values =  JsonConvert.DeserializeObject<List<ResultProductWithCategoryDtoUI>>(jsonData);
                return View(values);
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/Category");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<ResultCategoryDtoUI>>(jsonData);

                List<SelectListItem> selectListItems = (List<SelectListItem>)(from x in val
                                                        select new SelectListItem
                                                        {
                                                            Value = x.CategoryId.ToString(),
                                                            Text = x.CategoryName
                                                        }).ToList(); 
                ViewBag.SelectListItems = selectListItems;

            }

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductDtoUI createProductDtoUI)
        {
          
            createProductDtoUI.ImgUrl = await _fileUploadService.UploadFileAsync(createProductDtoUI.ImgFile, "images/ProductImages");
            
            
            // Bu şekilde kodlanmış bende gerek yok gibi. createProductDtoUI.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDtoUI);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json" );            
            var responseMessage = await client.PostAsync("https://localhost:44346/api/Product/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/Product/{id}");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(jsonData);

            await _fileUploadService.DeleteFileAsync(product?.ImgUrl);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id) 
        {

            //Dropdown için Categorilerin çekilmesi, yukarıdakinin aynısı
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<ResultCategoryDtoUI>>(jsonData);

                IEnumerable<SelectListItem> selectListItems = (IEnumerable<SelectListItem>)(from x in val
                                                                                            select new SelectListItem
                                                                                            {
                                                                                                Value = x.CategoryId.ToString(),
                                                                                                Text = x.CategoryName
                                                                                            });
                ViewBag.SelectListItems = selectListItems;

            }



            //Update için Product ın çekilmesi
            var responseMessage2 = await client.GetAsync($"https://localhost:44346/api/Product/{id}");
            if(responseMessage2.IsSuccessStatusCode)
            {   
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var val3 = JsonConvert.DeserializeObject<UpdateProductDtoUI>(jsonData);
                return View(val3);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDtoUI updateProductDtoUI)
        {


            //resim için işlemler
            if (updateProductDtoUI.ImgFile != null && updateProductDtoUI.ImgFile.Length > 0)
            {
                // Var olan dosya yolunu al
                var existingFilePath = updateProductDtoUI.ImgUrl;

                // Yeni dosyayı yükle ve eski dosyayı sil
                var newFilePath = await _fileUploadService.UpdateFileAsync(updateProductDtoUI.ImgFile, existingFilePath, "images/ProductImages");

                // DTO'yu güncelle
                updateProductDtoUI.ImgUrl = newFilePath;
            }

            
            //Api işlemleri
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDtoUI);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage2 = await client.PutAsync("https://localhost:44346/api/Product", stringContent);

            if(responseMessage2.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        //TODO: Bu sayfada validation uygula. değerler boş geçince farklı bir hata fırlatıyor, bunu incele


        


        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(productId);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"https://localhost:44346/api/Basket", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Json(productId);
        }

    }
}
