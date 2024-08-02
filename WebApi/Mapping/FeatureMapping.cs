using AutoMapper;
using DtoLayer.FeatureDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, CreateFeatureDto>().ReverseMap(); ;
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap(); ;
            CreateMap<Feature, GetFeatureDto>().ReverseMap(); ;
            CreateMap<Feature, ResultFeatureDto>().ReverseMap(); ;
        }
    }
}
