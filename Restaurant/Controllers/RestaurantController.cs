using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Entities;
using Restaurant.Models;
using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var name = _restaurantService.Create(dto);
            return Created($"restaurant/{name}", null);
        }

        //[HttpPost]
        //public ActionResult CreateDish([FromBody] CreateDishDto dto)
        //{
        //    var dish = _mapper.Map<Dish>(dto);
        //    _dbContext.Dishes.Add(dish);
        //    _dbContext.SaveChanges();

        //    return Created($"restaurant/{dish.Category}/{dish.Name}", null);
        //}

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllDishes()
        {
            var dishesDtos = _restaurantService.GetAll();

            return Ok(dishesDtos);
        }

        [HttpGet("{name}")]
        public ActionResult<Dish> GetDish([FromRoute] string name)
        {
            var dish = _restaurantService.GetById(name);

            if (dish is null)
            {
                return NotFound();
            }

            return Ok(dish);
        }
    }
}
