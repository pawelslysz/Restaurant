using Microsoft.AspNetCore.Mvc;
using Restaurant.Entities;
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

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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
    }
}
