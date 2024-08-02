using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.FeatureDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFeatureList()
        {
            var values = _featureService.TGetAll();
            var result = _mapper.Map<List<ResultFeatureDto>>(values);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            Feature value = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(value);

            return Ok("Öne çıkan oluşturma başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var valueToDel = _featureService.TGetById(id);
            _featureService.TDelete(valueToDel);

            return Ok("Öne çıkan silme başarılı");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            Feature valueToUpdate = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(valueToUpdate);

            return Ok("Öne çıkan güncelleme başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {

            Feature value = _mapper.Map<Feature>(_featureService.TGetById(id));

            return Ok(value);
        }
    }
}
