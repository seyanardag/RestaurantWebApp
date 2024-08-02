using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Dtos.BasketDto;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
           
        }
  
        public async Task<IActionResult> Index(int id)
        {           
            id = 4;  //TODO: burada masa sayısı masadaki QR koduyla veya müşteriden bir şekilde dinamik olarak gelmeli. 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44346/api/Basket/{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<ResultBasketDtoUI> result = JsonConvert.DeserializeObject<List<ResultBasketDtoUI>>(jsonData);


                var resultBasketViewModel = result.Select(x => new ResultBasketViewModel
                {
                    BasketId = x.BasketId,
                    Count = x.Count,
                    Price = x.Price,
                    TotalPrice = x.TotalPrice,
                    ProductName = x.Product.ProductName,
                    RestaurantTableId = x.RestaurantTableId,
                    ProductId = x.ProductId,

                }).ToList();


                var productGroup = resultBasketViewModel.GroupBy(x=>x.ProductId).ToList();

                var newList = new List<ResultBasketViewModel>();
                
                foreach ( var product in productGroup)
                {
                    var resultToAdd = new ResultBasketViewModel
                    {
                        ProductName = product.FirstOrDefault().ProductName,
                        ProductId = product.FirstOrDefault().ProductId,
                        Price = product.FirstOrDefault().Price,
                        RestaurantTableId = product.FirstOrDefault().RestaurantTableId,
                        BasketId = product.FirstOrDefault().BasketId,
                        Count = product.Count(),
                        TotalPrice = product.Count() * product.FirstOrDefault().Price
					};

                    newList.Add(resultToAdd);
                }
                

                return View(newList);
            }


            return View();
        }


  
        public async Task<IActionResult> DeleteFromBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44346/api/Basket/DeleteFromBasket/{id}");


            return RedirectToAction("Index");
        }


    }
}
