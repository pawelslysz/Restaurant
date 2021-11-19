using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class RestaurantController : Controller
    {
        private static IList<CreateRestaurant> restaurants = new List<CreateRestaurant>()
        {
            new CreateRestaurant(){ Name = "Hut", Description = "Dobra", HasDelivery = true},
            new CreateRestaurant(){ Name = "Dominium", Description = "Taka sobie", HasDelivery = false }
        };

        // GET: RestaurantController
        public ActionResult Index()
        {
            return View(restaurants);
        }

        // GET: RestaurantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestaurantController/Create
        public ActionResult Create()
        {
            return View(new CreateRestaurant());
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRestaurant createRestaurant)
        {
            restaurants.Add(createRestaurant);
            return RedirectToAction(nameof(Index));
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
