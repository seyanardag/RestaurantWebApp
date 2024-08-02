using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.BookingDto;

namespace WebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CreateNewBooking(CreateBookingDtoUI createBookingDtoUI)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDtoUI);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44346/api/Booking", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Product");
            }


            return View(createBookingDtoUI);
        }
    }
}
