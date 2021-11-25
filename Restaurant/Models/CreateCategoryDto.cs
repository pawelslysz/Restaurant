using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string DishName { get; set; }
        public float DishPrice { get; set; }
        public string DishDescription { get; set; }

    }
}
