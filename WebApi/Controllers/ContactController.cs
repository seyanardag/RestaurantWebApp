using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CategoryDto;
using DtoLayer.ContactDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCategory(CreateContactDto createContactDto)
        {

            Contact contact = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(contact);

            return Ok("İletişim biilgisi ekleme başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contactToDel = _contactService.TGetById(id);
            _contactService.TDelete(contactToDel);
            return Ok("Contact silme başarılı");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(contact);

            return Ok("Contact güncelleme başarılı");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            Contact contact = _contactService.TGetById(id);


            return Ok(contact);
        }

		[HttpPost("ChangeSelectedContact")]
        public IActionResult ChangeSelectedContact([FromBody] int id)
        {
            _contactService.TChangeSelectedContact(id);
            return Ok("Contact isSelected Prop value changed successfully");
        }

		[HttpPost("MakeAllContactIsselectedFalse")]
		public IActionResult MakeAllContactIsselectedFalse()
		{
			_contactService.TMakeAllContactIsselectedFalse();
            return Ok("All Contacts isSelected Prop values changed to False Successfully");
		}


	}
}
