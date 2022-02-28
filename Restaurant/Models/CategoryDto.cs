using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
