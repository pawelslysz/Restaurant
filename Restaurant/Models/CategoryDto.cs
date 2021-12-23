using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class CategoryDto
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        public List<DishDto> Dishes { get; set; }
    }
}
