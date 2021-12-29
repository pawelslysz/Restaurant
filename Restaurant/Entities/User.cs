using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone{ get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        //public virtual Order Order { get; set; }
    }
}
