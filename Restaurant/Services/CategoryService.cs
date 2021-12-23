using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public interface ICategoryService
    {

    }
    public class CategoryService : ICategoryService
    {
        private readonly RestaurantDbContext _dbContext;

        public CategoryService(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
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
