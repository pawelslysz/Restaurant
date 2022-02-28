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
    public interface IDishService
    {
        bool Delete(int id);
        IEnumerable<DishDto> GetAll();
        bool Create(UpdateCategoryDto dto);
        bool Update(UpdateCategoryDto dto);
        IEnumerable<DishDto> GetByCategory(string categoryName);
    }

    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public DishService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Create(UpdateCategoryDto dto)
        {
            var category = _dbContext
                .Categories
                .FirstOrDefault(c => c.Name == dto.CategoryName);

            if (category is null)
                return false;

            var allDishes = _dbContext
                .Dishes
                .ToList();

            foreach (var dishes in allDishes)
            {
                if (dishes.Name == dto.Name)
                    return false;
            }

            var dish = new Dish
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CategoryName = dto.CategoryName
            };

            category.Dishes.Add(dish);

            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(UpdateCategoryDto dto)
        {
            var dish = _dbContext
                .Dishes
                .FirstOrDefault(c => c.Id == dto.Id);

            if (dish is null)
                return false;
            
            dish.Name = dto.Name;
            dish.Price = dto.Price;
            dish.Description = dto.Description;
            dish.CategoryName = dto.CategoryName;

            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var dish = _dbContext
                .Dishes
                .FirstOrDefault(d => d.Id == id );

            if (dish is null)
                return false;

            _dbContext.Dishes.Remove(dish);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<DishDto> GetAll()
        {
            var dishes = _dbContext
                .Dishes
                .ToList();

            var dishesDtos = _mapper.Map<List<DishDto>>(dishes);

            return dishesDtos;
        }

        public IEnumerable<DishDto> GetByCategory(string categoryName)
        {
            var dishes = new List<Dish>();
            foreach (var dish in _dbContext.Dishes)
            {
                if (dish.CategoryName == categoryName)
                    dishes.Add(dish);
            }

            var dishesDtos = _mapper.Map<List<DishDto>>(dishes);

            return dishesDtos;
        }
    }
}
