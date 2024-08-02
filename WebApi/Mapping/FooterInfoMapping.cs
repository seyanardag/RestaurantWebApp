using AutoMapper;
using DtoLayer.FooterInfoDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
    public class FooterInfoMapping : Profile
    {
        public FooterInfoMapping()
        {
            CreateMap<FooterInfo, CreateFooterInfoDto>().ReverseMap();
            CreateMap<FooterInfo, UpdateFooterInfoDto>().ReverseMap();
            CreateMap<FooterInfo, GetFooterInfoDto>().ReverseMap();
            CreateMap<FooterInfo, ResultFooterInfoDto>().ReverseMap();
        }
    }
}
