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
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;
        private readonly IMapper _mapper;

        public DishController(IDishService dishService, IMapper mapper)
        {
            _dishService = dishService;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult Create([FromBody] UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isCreated = _dishService.Create(dto);

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

            var isUpdated = _dishService.Update(dto);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _dishService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }


        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllDishes()
        {
            var dishesDtos = _dishService.GetAll();

            return Ok(dishesDtos);
        }

        [Route("list/{categoryName}")]
        [HttpGet]
        public ActionResult<IEnumerable<DishDto>> GetDishesByCategory([FromRoute] string categoryName)
        {
            var dishesDtos = _dishService.GetByCategory(categoryName);

            return Ok(dishesDtos);
        }

    }
}
