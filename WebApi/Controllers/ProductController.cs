using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.ProductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            var values = _productService.TGetAll();
            var result = _mapper.Map<List<ResultProductDto>>(values);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);

            return Ok("Ürün oluşturma başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var valueToDel = _productService.TGetById(id);
            _productService.TDelete(valueToDel);

            return Ok(valueToDel);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product valueToUpdate = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(valueToUpdate);

            return Ok("Ürün güncelleme başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {

            Product value = _mapper.Map<Product>(_productService.TGetById(id));

            return Ok(value);
        }

        [HttpGet("GetProductsWithCategories")]
        public IActionResult GetProductsWithCategories()
        {
        //TODO: Burada mimariye daha uygun şekilde bir yazım yazılabilir. Business ve Dal katmanlarındaki GetProductsWithCategories yazılmıştı onlar boşa çıktı, kulllanılmazsa silinebilir.
            var context = new signalRContext();
            var result = context.Products.Include(x=>x.Category).Select(y=> new ResultProductWithCategoryDto()
            {
                ProductName= y.ProductName,
                Description= y.Description,
                ImgUrl= y.ImgUrl,
                Price= y.Price,
                ProductId= y.ProductId,
                ProductStatus= y.ProductStatus,
                CategoryName = y.Category.CategoryName
            }) ;

            return Ok(result.ToList());
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_productService.TGetProductCount());
        }


		[HttpGet("GetProductCountByHamburger")]
		public IActionResult GetProductCountByHamburger()
		{
			return Ok(_productService.TGetProductCountByHamburger());
		}
		
		[HttpGet("GetProductCountByCategoryDrink")]
		public IActionResult GetProductCountByCategoryDrink()
		{
			return Ok(_productService.TGetProductCountByCategoryDrink());
		}

        [HttpGet("GetAverageProductPrice")]
        public IActionResult GetAverageProductPrice()
        {
            return Ok(_productService.TGetAverageProductPrice());
        }
        [HttpGet("GetProductNameByMaxPrice")]
        public IActionResult GetProductNameByMaxPrice()
        {
            return Ok(_productService.TGetProductNameByMaxPrice());
        } 
        [HttpGet("GetProductNameByMinPrice")]
        public IActionResult GetProductNameByMinPrice()
        {
            return Ok(_productService.TGetProductNameByMinPrice());
        }

        [HttpGet("AverageHamburgerPrice")]
		public IActionResult AverageHamburgerPrice()
        {
            return Ok(_productService.TAverageHamburgerPrice());
        }





	}
}
