using AutoMapper;
using DtoLayer.ContactFormMessageDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
	public class ContactFormMessageMapping : Profile
	{
        public ContactFormMessageMapping()
        {
            CreateMap<ContactFormMessage, ResultContactFormMessageDto>().ReverseMap();
            CreateMap<ContactFormMessage, UpdateContactFormMEssageDto>().ReverseMap();
            CreateMap<ContactFormMessage, CreateContactFormMEssageDto>().ReverseMap();
            CreateMap<ContactFormMessage, GetContactFormMessageDto>().ReverseMap();
        }
    }
}
