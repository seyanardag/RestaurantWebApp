﻿using AutoMapper;
using DtoLayer.ProductDto;
using EntityLayer.Entities;

namespace WebApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
        }
    }
}
