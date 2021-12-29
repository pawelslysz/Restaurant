using AutoMapper;
using Restaurant.Entities;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public interface ICategoryService
    {
        bool Delete(string name);
        bool Update(CategoryDto dto);
        bool Create(CategoryDto dto);
        IEnumerable<Category> Get();
    }
    public class CategoryService : ICategoryService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Delete(string name)
        {
            var category = _dbContext
                .Categories
                .FirstOrDefault(c => c.Name == name);

            if (category is null)
                return false;

            foreach (var dish in _dbContext.Dishes)
            {
                if (dish.CategoryName == name)
                    _dbContext.Dishes.Remove(dish);
            }
            
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(CategoryDto dto)
        {
            // var categoryDto = _dbContext
            //   .Categories
            // .FirstOrDefault(c => c.Id == dto.Id);

            var category = _dbContext
                .Categories
                .FirstOrDefault(c => c.Name == dto.Name);

            category.Description = dto.Description;
            category.Picture = dto.Picture;

            _dbContext.SaveChanges();
            return true;
        }

        public bool Create(CategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                Picture = dto.Picture
            };

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<Category> Get()
        {
            var categories = _dbContext
                .Categories
                .ToList();

            return categories;
        }
    }
}
