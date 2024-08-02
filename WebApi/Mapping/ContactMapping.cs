using AutoMapper;
using DtoLayer.ContactDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
        }
    }
}
