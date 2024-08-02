using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.TestimonialDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTestimonialList()
        {
            var values = _testimonialService.TGetAll();
            var result = _mapper.Map<List<ResultTestimonialDto>>(values);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);

            return Ok("Müşteri yorumu oluşturma başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var valueToDel = _testimonialService.TGetById(id);
            _testimonialService.TDelete(valueToDel);

            return Ok(valueToDel);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial valueToUpdate = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(valueToUpdate);

            return Ok(valueToUpdate);
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {

            var value = _mapper.Map<GetTestimonialDto>(_testimonialService.TGetById(id));

            return Ok(value);
        }
    }
}
