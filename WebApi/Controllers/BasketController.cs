using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.BasketDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public BasketController(IBasketService basketService, IMapper mapper, IProductService productService)
        {
            _basketService = basketService;
            _mapper = mapper;
            _productService = productService;
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var values = _basketService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetRestaurantTableBasket(int id)
        {
            var values = _basketService.TGetRestaurantTableBasket(id);
            return Ok(values);
        }

        [HttpPost("CreateBasket")]
        public IActionResult CreateBasket(int ProductID)
        {
            //TODO: Burada TableID değerinin de olması lazım, bunu ilerleyen bölümde table lar nasıl seçilirse oradan almak gerek, mesela login olduysa login yapan user bilgisinden, karekod dan vs ise belki oradan olabilir. 
            Product product = _productService.TGetById(ProductID);

            Basket value = new Basket()
            {
                Count = 1,
                Price = product.Price,
                ProductId = ProductID,
                RestaurantTableId = 4, //Burada revize olmalı
                TotalPrice = product.Price
            };

            _basketService.TAdd(value);
            return Ok("Sepete ekleme başarılı");
        }
        [HttpDelete("DeleteFromBasket/{id}")]
        public IActionResult DeleteFromBasket(int id)
        {
            var basketToDel = _basketService.TGetById(id);
            _basketService.TDelete(basketToDel);
            return Ok("Basket ten ürün silme başarılı");
        }


    }
}
