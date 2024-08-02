using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.BookingDto;

namespace WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //TODO: Burası daha önce normal olarak tasarlandı, sonra buranın karşılığındaki tablo SignalR ile yeniden kodlandı, bu ksıım gereksiz olduğundan comment e alındı.
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:44346/api/Booking");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultBookingDtoUI>>(jsonData);
            //    return View(values);
            //}


            return View();
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDtoUI createBookingDtoUI)
        {           
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDtoUI);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44346/api/Booking", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View(createBookingDtoUI);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/Booking/{id}");


            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44346/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var Booking = JsonConvert.DeserializeObject<UpdateBookingDtoUI>(json);

                return View(Booking);

            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDtoUI updateBookingDtoUI)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDtoUI);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:44346/api/Booking/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(updateBookingDtoUI);
        }

        [HttpGet]
        public async Task<IActionResult> ApproveBooking(int id)
        {

            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:44346/api/Booking/ApproveBooking/{id}");
     

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> CancelBooking(int id)
        {

            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:44346/api/Booking/CancelBooking/{id}");
      
            return RedirectToAction("Index");
        }


    }
}
