using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ContactFormMessageDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormMessageController : ControllerBase
    {
        private readonly IContactFormMessageService _contactFormMessageService;
        private readonly IMapper _mapper;

        public ContactFormMessageController(IContactFormMessageService contactFormMessageService, IMapper mapper)
        {
            _contactFormMessageService = contactFormMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactFormMessageList()
        {
            var values = _contactFormMessageService.TGetAll();
            var mappedValues = _mapper.Map<List<ResultContactFormMessageDto>>(values);

            return Ok(mappedValues);
        }

        [HttpGet("{id}")]
        public IActionResult ContactFormMessageById(int id)
        {
            var value = _contactFormMessageService.TGetById(id);
            var mappedValue = _mapper.Map<GetContactFormMessageDto>(value);
            return Ok(mappedValue);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContactFormMessage(int id)
        {
            var value = _contactFormMessageService.TGetById(id);
            _contactFormMessageService.TDelete(value);
            return Ok("Form Mesajı silme başarılı");
        }

        [HttpPost]
        public IActionResult AddContactFormMessage(CreateContactFormMEssageDto message)
        {
            var value = _mapper.Map<ContactFormMessage>(message);
            _contactFormMessageService.TAdd(value);

            return Ok("Form mesajı ekleme başarılı");
        }

        [HttpPut]
        public IActionResult UpdateFormMessage(UpdateContactFormMEssageDto message)
        {
            var value = _mapper.Map<ContactFormMessage>(message);
            _contactFormMessageService.TUpdate(value);
            return Ok("Form Mesajı güncelleme başarılı");

        }




        [HttpGet("MarkAsRead/{id}")]
        public IActionResult MarkAsRead(int id)
        {
            var contact = _contactFormMessageService.TGetById(id);
            contact.IsRead = true;
            _contactFormMessageService.TUpdate(contact);

            return Ok("Mesaj okundu olarak işaretlendi");
        }

        [HttpGet("MarkAsUnRead/{id}")]
        public IActionResult MarkAsUnRead(int id)
        {
            var contact = _contactFormMessageService.TGetById(id);
            contact.IsRead = false;
            _contactFormMessageService.TUpdate(contact);

            return Ok("Mesaj okundu olarak işaretlendi");
        }



    }
}
