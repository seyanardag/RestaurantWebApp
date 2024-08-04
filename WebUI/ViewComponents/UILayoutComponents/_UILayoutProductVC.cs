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



            var responseMessage = await client.GetAsync("https://localhost:44346/api/Product/GetProductsWithCategories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDtoUI>>(json);

                var actionDescriptor = ViewContext.ActionDescriptor as ControllerActionDescriptor;
                string actionName = actionDescriptor?.ActionName;
                ViewBag.ActionName = actionName;

                if (actionName == "MainPage")  //Anasayfada ise sadece ilk 9 ürün, Menu sayfasında ise bütün ürünler listeleniyor
                {
                    var filteredProducts = result.Where(x => x.ProductStatus == true).OrderByDescending(x => x.ProductId).Take(9).ToList();
                    var filteredCategories = filteredProducts.Select(x=>x.CategoryName).Distinct().ToList();
					ViewBag.Categories = filteredCategories;

					return View(filteredProducts);
                }
                else
                {
                    var filteredProducts = result.Where(x => x.ProductStatus == true).OrderByDescending(x => x.ProductId).ToList();
					var filteredCategories = filteredProducts.Select(x => x.CategoryName).Distinct().ToList();
					ViewBag.Categories = filteredCategories;
					return View(filteredProducts);
                }


            }



            return View();
        }
    }
}