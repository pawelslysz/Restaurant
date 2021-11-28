using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class UpdateCategoryDto
    {
        public string DishName { get; set; }
        public float DishPrice { get; set; }
        public string DishDescription { get; set; }
    }
}
