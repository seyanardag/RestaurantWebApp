using AutoMapper;
using DtoLayer.OpenHourDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
    public class OpenHourMapping : Profile
    {
        public OpenHourMapping()
        {
            CreateMap<OpenHour, CreateOpenHourDto>().ReverseMap();
            CreateMap<OpenHour, GetOpenHourDto>().ReverseMap();
            CreateMap<OpenHour, UpdateOpenHourDto>().ReverseMap();
            CreateMap<OpenHour, ResultOpenHourDto>().ReverseMap();

        }
    }
}
