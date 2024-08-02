using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.FooterInfoDto;
using WebUI.Dtos.SocialMediaDto;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class UILayoutSocialMediaVC : ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public UILayoutSocialMediaVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/SocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultSocialMediaDtoUI>>(jsonData);
                var activeData = result.Where(x => x.IsActive).ToList();
                return View(activeData);
            }


            return View();
        }
    }
}
