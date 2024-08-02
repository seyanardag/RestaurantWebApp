using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.AboutDto;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutAboutVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutAboutVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/About/getSelectedAbout");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultAboutDtoUI>(jsonData);
                return View(result);
            }

            return View();
        }
    }
}
