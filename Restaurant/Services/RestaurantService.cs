using Restaurant.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Services
{
    public interface IRestaurantService
    {
        Category Create(CreateCategoryDto dto);
        bool Delete(int id);
        IEnumerable<DishDto> GetAll();
        Dish GetById(string name);
        bool Update(UpdateCategoryDto dto);//, int id);
    }

    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Dish GetById(string name)
        {
            var dish = _dbContext
                .Dishes
                .FirstOrDefault(d => d.Name == name);

            if (dish is null)
            {
                return null;
            }

            var result = dish;
            return result;
        }

        public IEnumerable<DishDto> GetAll()
        {
            var dishes = _dbContext
                .Dishes
                .ToList();

            var dishesDtos = _mapper.Map<List<DishDto>>(dishes);

            return dishesDtos;
        }

        public Category Create(CreateCategoryDto dto)
        {
            var category = new Category();
            category.Name = dto.Name;
            category.Picture = dto.Picture;
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return category;
        }

        public bool Update(UpdateCategoryDto dto)//, int id)
        {
            var category = _dbContext
                .Categories
                .FirstOrDefault(c => c.Name == dto.Category);

            if (category is null)
                return false;

            var dish = new Dish
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description
            };

            category.Dishes.Add(dish);

            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var dish = _dbContext
                .Dishes
                .FirstOrDefault(d => d.Id == id);

            if (dish is null)
                return false;

            _dbContext.Dishes.Remove(dish);
            _dbContext.SaveChanges();

            return true;
        }
        
    }
}
