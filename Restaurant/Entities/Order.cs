using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public DateTime DateOfOrder { get; set; }

        public int UserId { get; set; }
        public int DishId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
