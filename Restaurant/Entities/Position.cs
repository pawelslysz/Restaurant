using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Salary { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
