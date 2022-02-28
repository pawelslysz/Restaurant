using AutoMapper;
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
            CreateMap<CategoryDto, Category>();
            CreateMap<Dish, DishDto>();

            CreateMap<CreateDishDto, Dish>();

            CreateMap<CategoryDto, Category>();

            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(m => m.Dishes, c => c.MapFrom
                (dto => new Dish()
                    { 
                        Name = dto.Name, 
                        Price = dto.Price, 
                        Description = dto.Description 
                    }
                ));

            CreateMap<Order, OrderDto>();

            CreateMap<Dish, DishOrderDto>();
        }
    }
}
