using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using DtoLayer.CategoryDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            Category category = new Category()
            {
               CategoryName = createCategoryDto.CategoryName,
               Status = createCategoryDto.Status,
            };

            _categoryService.TAdd(category);

            return Ok("Kategori ekleme başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var categoryToDel = _categoryService.TGetById(id);
            _categoryService.TDelete(categoryToDel);
            return Ok("Rezervasyon silme başarılı");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategory)
        {
            Category category = new Category()
            {
                CategoryId = updateCategory.CategoryId,
                CategoryName=updateCategory.CategoryName,
                Status=updateCategory.Status,
            };

            _categoryService.TUpdate(category);


            return Ok("Kategori güncelleme başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            return Ok(_categoryService.TGetById(id));
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            return Ok(_categoryService.TGetCategoryCount());
        }
        [HttpGet("GetActiveCategoryCount")]
        public IActionResult GetActiveCategoryCount()
        {
            return Ok(_categoryService.TGetActiveCategoryCount());
        }
        [HttpGet("GetPassiveCategoryCount")]
        public IActionResult GetPassiveCategoryCount()
        {
            return Ok(_categoryService.TGetPassiveCategoryCount());
        }

	}
}
