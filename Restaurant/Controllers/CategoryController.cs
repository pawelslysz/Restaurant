using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Services;
using Restaurant.Entities;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Route("restaurant/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpDelete("{name}")]
        public ActionResult Delete([FromRoute] string name)
        {
            var isDeleted = _categoryService.Delete(name);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut]
        public ActionResult Update([FromBody] CategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isUpdated = _categoryService.Update(dto);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult Create([FromBody] CategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isCreated = _categoryService.Create(dto);

            if (!isCreated)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _categoryService.Get();

            return Ok(categories);
        }
    }
}
