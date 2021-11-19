using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Prize { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

    }
}
