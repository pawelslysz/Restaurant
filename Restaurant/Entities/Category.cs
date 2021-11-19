using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        public virtual List<Dish> Dish { get; set; }
    }
}
