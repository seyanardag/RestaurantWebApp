using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.FooterInfoDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterInfoController : ControllerBase
    {
        private readonly IFooterInfoService _footerInfoService;

        private readonly IMapper _mapper;

        public FooterInfoController(IFooterInfoService footerInfoService, IMapper mapper)
        {
            _footerInfoService = footerInfoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFooterInfoList()
        {
            var values = _footerInfoService.TGetAll();
            var result = _mapper.Map<List<ResultFooterInfoDto>>(values);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFooterInfo(CreateFooterInfoDto createFooterInfoDto)
        {
            FooterInfo value = _mapper.Map<FooterInfo>(createFooterInfoDto);
            _footerInfoService.TAdd(value);

            return Ok("Footer info oluşturma başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFooterInfo(int id)
        {
            var valueToDel = _footerInfoService.TGetById(id);
            _footerInfoService.TDelete(valueToDel);

            return Ok("FooterInfo silme başarılı");
        }
        [HttpPut]
        public IActionResult UpdateFooterInfo(UpdateFooterInfoDto updateFooterInfoDto)
        {
            FooterInfo valueToUpdate = _mapper.Map<FooterInfo>(updateFooterInfoDto);
            _footerInfoService.TUpdate(valueToUpdate);

            return Ok("FooterInfo güncelleme başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetFooterInfo(int id)
        {

            FooterInfo value = _mapper.Map<FooterInfo>(_footerInfoService.TGetById(id));

            return Ok(value);
        }
    }
}
