using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.DiscountedProductDto;
using WebUI.Dtos.FeatureDto;

namespace WebUI.ViewComponents.UILaayoutComponents
{
    public class _UILayoutOfferVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutOfferVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/DiscountedProduct");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultDiscountedProductDtoUI>>(jsonData);
                var activeDiscountedProducts = result.Where(x=>x.isActive==true).ToList();
                return View(activeDiscountedProducts);

            }


            return View();
        }
    }
}
