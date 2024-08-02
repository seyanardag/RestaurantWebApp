using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSocialMediaList()
        {
            var values = _socialMediaService.TGetAll();
            var result = _mapper.Map<List<ResultSocialMediaDto>>(values);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            SocialMedia value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(value);

            return Ok("Sosyal medya oluşturma başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var valueToDel = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(valueToDel);

            return Ok("Sosyal medya silme başarılı");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            SocialMedia valueToUpdate = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(valueToUpdate);

            return Ok("Sosyal medya güncelleme başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {

            SocialMedia value = _mapper.Map<SocialMedia>(_socialMediaService.TGetById(id));

            return Ok(value);
        }
    }
}
