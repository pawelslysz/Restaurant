using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Services;
using Restaurant.Entities;

namespace Restaurant.Controllers
{
    [Route("restaurant/categories")]
    public class CategoryController
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public Action<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _categoryService.Get();

            return Ok(categories);
        }
    }
}
