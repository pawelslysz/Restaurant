using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }  
        [Required]
        public string CategoryName { get; set; }
    }
}
