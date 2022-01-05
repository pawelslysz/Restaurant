using AutoMapper;
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
    [Route("restaurant/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _orderService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
            }

        [HttpPost]
        public ActionResult Create([FromBody] Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isCreated = _orderService.Create(dish);

            if (!isCreated)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> Get()
        {
            var orders = _orderService.Get();

            return Ok(orders);
        }
    }
}
