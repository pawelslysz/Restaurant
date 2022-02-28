using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public bool IsOrdered { get; set; }
        public List<DishOrderDto> Dishes { get; set; }
    }
}
