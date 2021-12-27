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
    [Route("restaurant/menu")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult Create([FromBody] UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isCreated = _restaurantService.Create(dto);

            if (!isCreated)
            {
                return NotFound();
            }
            return Ok();
        }


        [HttpPut]
        public ActionResult Update([FromBody] UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isUpdated = _restaurantService.Update(dto);

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


        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllDishes()
        {
            var dishesDtos = _restaurantService.GetAll();

            return Ok(dishesDtos);
        }

        //[HttpGet("{name}")]
        //public ActionResult<Dish> GetDish([FromRoute] string name)
        //{
        //    var dish = _restaurantService.GetById(name);

        //    if (dish is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dish);
        //}
    }
}
