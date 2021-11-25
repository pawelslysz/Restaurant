﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Entities;
using Restaurant.Models;

namespace Restaurant
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Dish, DishDto>();

            CreateMap<CreateDishDto, Dish>()
                .ForMember(m => m.Category, c => c.MapFrom(s => s.Category))
                .ForMember(m => m.CategoryId, c => c.MapFrom(s => s.CategoryId));

            CreateMap<CreateCategoryDto, Category>()
                .ForMember(m => m.Dishes, c => c.MapFrom(dto => new Dish()
                    {Name = dto.DishName, Price = dto.DishPrice, Description = dto.DishDescription}));
        }
    }
}
