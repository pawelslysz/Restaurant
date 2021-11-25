using Restaurant.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Services
{
    public interface IRestaurantService
    {
        string Create(CreateCategoryDto dto);
        IEnumerable<CategoryDto> GetAll();
        Dish GetById(string name);
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

        public IEnumerable<CategoryDto> GetAll()
        {
            var dishes = _dbContext
                .Categories
                .ToList();

            var dishesDtos = _mapper.Map<List<CategoryDto>>(dishes);

            return dishesDtos;
        }

        public string Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return category.Name;
        }

    }
}
