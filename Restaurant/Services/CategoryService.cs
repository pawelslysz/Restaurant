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

        public bool Update(CategoryDto dto)
        {
           // var categoryDto = _dbContext
             //   .Categories
               // .FirstOrDefault(c => c.Id == dto.Id);

            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Create(CategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
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
