using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Entities;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public interface IOrderService
    {
        bool Delete(int id);
        bool Create(Dish dish);
        IEnumerable<OrderDto> Get();
        IEnumerable<OrderDto> GetForUser();
        bool Update(Dish dish);
        bool UpdateIsOrdered(int id);
    }
    public class OrderService : IOrderService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Delete(int id)
        {
            var order = _dbContext
                .Orders
                .FirstOrDefault(o => o.Id == id);

            if (order is null)
                return false;

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(Dish dish)
        {
            var theDish = _dbContext
                .Dishes
                .FirstOrDefault(d => d.Id == dish.Id);

            var order = _dbContext
                .Orders
                .OrderByDescending(o => o.Id)
                .FirstOrDefault();

            foreach (var thisDish in order.Dishes)
            {
                if (thisDish == theDish)
                    return false;
            }

            order.Dishes.Add(theDish);
            order.Price += dish.Price;

            _dbContext.SaveChanges();

            return true;
        }

        public bool UpdateIsOrdered(int id)
        {
            var thisOrder = _dbContext
                .Orders
                .FirstOrDefault(o => o.Id == id);
            thisOrder.IsOrdered = true;

            _dbContext.SaveChanges();
            return true;
        }

        public bool Create(Dish dish)
        {
            var theDish = _dbContext
                .Dishes
                .FirstOrDefault(d => d.Id == dish.Id);

            var order = new Order
            {
                Price = theDish.Price,
                DateOfOrder = DateTime.Now,
            };
            order.Dishes.Add(theDish);

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return true;            
        }
        
        public IEnumerable<OrderDto> Get()
        {
            var orders = _dbContext
                .Orders
                .Include(o => o.Dishes)
                .Where(o => o.IsOrdered==true)
                .ToList();

            var ordersDtos = _mapper.Map<List<OrderDto>>(orders);

            return ordersDtos;
        }

        public IEnumerable<OrderDto> GetForUser()
        {
            var orders = _dbContext
                .Orders
                .Include(o => o.Dishes)
                .ToList();


            var ordersDtos = _mapper.Map<List<OrderDto>>(orders);

            return ordersDtos;
        }

    }
}
