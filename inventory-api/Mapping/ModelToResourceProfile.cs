using System;
using AutoMapper;
using inventoryapi.Domain.Models;
using inventoryapi.Resources;

namespace inventoryapi.Mappings
{
    // This profile extends AutoMapper.Profile
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<Property, PropertyResource>();
        }
    }
}
