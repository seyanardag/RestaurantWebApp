using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.Dtos.AboutDto;
using WebUI.Dtos.TestimonialDto;

namespace WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutClientVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutClientVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44346/api/Testimonial");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultTestimonialDtoUI>>(jsonData);
                var activeTestimonials = result.Where(x=>x.Status == true).ToList();
                return View(activeTestimonials);
            }

            return View();
          
        }
    }
}
