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
        private readonly IMapper _mapper;
        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [Route("menu")]
        [HttpPost]
        public ActionResult CreateCategory([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = _restaurantService.Create(dto);
            var create = _mapper.Map<Category>(category);
            return Created($"restaurant/{create.Name}", null);
        }

        [HttpPut("menu")]
        public ActionResult Update([FromBody] UpdateCategoryDto dto)//, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isUpdated = _restaurantService.Update(dto);//, id);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _restaurantService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [Route("menu")]
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
