using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.FeatureDto;

namespace WebUI.ViewComponents.UILaayoutComponents
{
    public class _UILayoutMainSliderVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutMainSliderVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/Feature");

            if (responseMessage.IsSuccessStatusCode)
            {
                 var jsonData = await responseMessage.Content.ReadAsStringAsync();
                 var result = JsonConvert.DeserializeObject<List<ResultFeatureDtoUI>>(jsonData);
                return View(result);

            }


            return View();
        }
    }
}
