using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public interface IOrderService
    {
        bool Create(Dish dish);
    }
    public class OrderService : IOrderService
    {
        private RestaurantDbContext _dbContext;

        public OrderService(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Dish dish)
        {
            var theDish = _dbContext
                .Dishes
                .Where(d => d.Id == dish.Id)
                .ToList();

            var order = new Order
            {
                Price = dish.Price,
                DateOfOrder = DateTime.Now,
                //Dishes = new List<Dish> { dish }
                
            };
            order.Dishes.Add(dish);

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();


            //using (var dish = new RestaurantDbContext())
            //{
            //    //var dishes = from d in dish.Dishes
            //    //             where d.Id == order.DishId
            //    //             select d;

            //    var newOrder = new Order
            //    {
            //        //Dishes = (ICollection<Dish>)dishes,
            //        DateOfOrder = DateTime.Now,
            //        Price = order.Price,
            //        Dishes = order.Dishes
            //        //DishId = order.DishId
            //    };

            //    _dbContext.Orders.Add(newOrder);
            //    _dbContext.SaveChanges();
            //}

            return true;            
        }
        
    }
}
