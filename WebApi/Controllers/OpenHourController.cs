using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.OpenHourDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenHourController : ControllerBase
    {
        private readonly IOpenHourService _openHourService;

        private readonly IMapper _mapper;

        public OpenHourController(IOpenHourService openHourService, IMapper mapper)
        {
            _openHourService = openHourService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOpenHourList()
        {
            var values = _openHourService.TGetAll();
            var result = _mapper.Map<List<ResultOpenHourDto>>(values);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOpenHour(CreateOpenHourDto createOpenHourDto)
        {
            OpenHour value = _mapper.Map<OpenHour>(createOpenHourDto);
            _openHourService.TAdd(value);

            return Ok("Açık saatleri oluşturma başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOpenHour(int id)
        {
            var valueToDel = _openHourService.TGetById(id);
            _openHourService.TDelete(valueToDel);

            return Ok("Açık saatleri silme başarılı");
        }
        [HttpPut]
        public IActionResult UpdateOpenHour(UpdateOpenHourDto updateOpenHourDto)
        {
            OpenHour valueToUpdate = _mapper.Map<OpenHour>(updateOpenHourDto);
            _openHourService.TUpdate(valueToUpdate);

            return Ok("Açık saatleri güncelleme başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetOpenHour(int id)
        {

            OpenHour value = _mapper.Map<OpenHour>(_openHourService.TGetById(id));

            return Ok(value);
        }
    }
}
