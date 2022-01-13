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

        [HttpPut]
        public ActionResult Update([FromBody] Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isUpdated = _orderService.Update(dish);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPatch]
        public ActionResult UpdateIsOrdered([FromBody] int id)
        {
            var isUpdated = _orderService.UpdateIsOrdered(id);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
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

        [Route("list")]
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetForUser()
        {
            var orders = _orderService.GetForUser();

            return Ok(orders);
        }

    }
}
