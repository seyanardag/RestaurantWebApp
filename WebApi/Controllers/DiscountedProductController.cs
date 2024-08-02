using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountedProductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountedProductController : ControllerBase
    {
        private readonly IDiscountedProductService _discountedProductService;

        private readonly IMapper _mapper;
        public DiscountedProductController(IDiscountedProductService discountedProductService, IMapper mapper)
        {
            _discountedProductService = discountedProductService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDiscountedProductList()
        {
            var values = _discountedProductService.TGetAll();
            var result = _mapper.Map<List<ResultDiscountedProductDto>>(values);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDiscountedProduct(CreateDiscountedProductDto createDiscountedProductDto)
        {
            DiscountedProduct value = _mapper.Map<DiscountedProduct>(createDiscountedProductDto);
            _discountedProductService.TAdd(value);

            return Ok("İndirimli ürün oluşturma başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscountedProduct(int id)
        {
            var valueToDel = _discountedProductService.TGetById(id);
            _discountedProductService.TDelete(valueToDel);

            return Ok(valueToDel);
        }
        [HttpPut]
        public IActionResult UpdateDiscountedProduct(UpdateDiscountedProductDto updateDiscountedProductDto)
        {
            var valueToUpdate = _mapper.Map<DiscountedProduct>(updateDiscountedProductDto);
            _discountedProductService.TUpdate(valueToUpdate);

            return Ok(valueToUpdate);
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscountedProduct(int id)
        {

            DiscountedProduct value = _mapper.Map<DiscountedProduct>(_discountedProductService.TGetById(id));

            return Ok(value);
        }

    }
}
