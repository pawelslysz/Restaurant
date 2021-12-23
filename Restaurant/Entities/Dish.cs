using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class Dish
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        public string CategoryName { get; set; }
        public virtual Category Category { get; set; }
        public virtual Order Order { get; set; }
    }
}
