using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.AboutDto;
using WebUI.Dtos.ContactDto;
using WebUI.Dtos.FooterInfoDto;
using WebUI.Dtos.OpenHourDto;

namespace WebUI.ViewComponents.UILaayoutComponents
{
    public class _UILayoutFooterVC : ViewComponent
    {

        public readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage =await client.GetAsync("https://localhost:44346/api/FooterInfo");
            var responseMessage2 =await client.GetAsync("https://localhost:44346/api/OpenHour");
            var responseMessage3 =await client.GetAsync("https://localhost:44346/api/Contact");

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultOpenHourDtoUI>>(jsonData).Where(x=>x.IsActive == true).FirstOrDefault();
                ViewBag.OpenDays = result?.OpenDays;
                ViewBag.OpeningHour = result?.OpeningHour;
                ViewBag.ClosingHour = result?.ClosingHour;
            }


            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultContactDtoUI>>(jsonData).FirstOrDefault();
                ViewBag.Location = result?.Location;
                ViewBag.Phone = result?.Phone;
                ViewBag.Email = result?.Email;
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultFooterInfoDtoUI>>(jsonData);
                
                return View(result?.Where(x => x.IsActive == true).FirstOrDefault());
            }


            return View();
        }
    }
}
