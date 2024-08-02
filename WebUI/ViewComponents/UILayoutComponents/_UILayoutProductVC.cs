using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using WebUI.Dtos.CategoryDto;
using WebUI.Dtos.ProductDto;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutProductVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutProductVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();


            var responseMessage2 = await client.GetAsync("https://localhost:44346/api/Category");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var json = await responseMessage2.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultCategoryDtoUI>>(json);
                List<string> categories = result.Where(x=>x.Status==true).Select(x => x.CategoryName).ToList();
                ViewBag.Categories = categories;
            }



            var responseMessage = await client.GetAsync("https://localhost:44346/api/Product/GetProductsWithCategories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDtoUI>>(json);

                var actionDescriptor = ViewContext.ActionDescriptor as ControllerActionDescriptor;
                string actionName = actionDescriptor?.ActionName;

                if (actionName == "MainPage")  //Anasayfada ise sadece ilk 9 ürün, Menu sayfasında ise bütün ürünler listeleniyor
                {
                    var filteredProducts = result.Where(x => x.ProductStatus == true).OrderByDescending(x => x.ProductId).Take(9).ToList();
                    return View(filteredProducts);
                }
                else
                {
                    var filteredProducts = result.Where(x => x.ProductStatus == true).OrderByDescending(x => x.ProductId).ToList();
                    return View(filteredProducts);
                }


            }



            return View();
        }
    }
}