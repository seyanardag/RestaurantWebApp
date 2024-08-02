using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }



        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            _aboutService.TmakeAllAboutIsselectedFalse();
            About about = new About()
            {
                Description = createAboutDto.Description,
                ImgUrl = createAboutDto.ImgUrl,
                Title = createAboutDto.Title,
                isSelected=true
            };

            _aboutService.TAdd(about);
            return Ok("Hakkımda kısmı ekleme başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var about = _aboutService.TGetById(id);
            _aboutService.TDelete(about);

            return Ok(about);
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            _aboutService.TmakeAllAboutIsselectedFalse();
            About about = new About()
            {
                AboutId=updateAboutDto.AboutId,
                Description = updateAboutDto.Description,
                ImgUrl = updateAboutDto.ImgUrl,
                Title = updateAboutDto.Title,
                isSelected=true,

            };

            _aboutService.TUpdate(about);
            return Ok("Hakkımda kısmı güncelleme başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout( int id)
        { 
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpPost("changeSelectedAbout")]
        public IActionResult changeSelectedAbout([FromBody] int id)
        {

            _aboutService.TchangeSelectedAbout(id);
            return Ok("About prop changed successfully");
        }

        [HttpGet("makeAllAboutIsselectedFalse")]
        public IActionResult makeAllAboutIsselectedFalse()
        {
            _aboutService.TmakeAllAboutIsselectedFalse();
            return Ok("All about row's isselected fields made false");
        }
        [HttpGet("getSelectedAbout")]
        public IActionResult GetSelectedAbout()
        {
            var selectedAbout = _aboutService.TGetAll().Where(x=>x.isSelected == true).FirstOrDefault();

            if(selectedAbout == null)
            {
                About defaultAbout = new About()
                {
                    AboutId = 1,
                    Description = "Sayın admin, Lütfen bir about seçiniz",
                    isSelected = true,
                    Title = "About seçilmemiş!",
                    ImgUrl = "testImage",

                };
                return Ok(defaultAbout);

            }

            return Ok(selectedAbout);
        }





	}
}
