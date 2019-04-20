using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodApplication.Models;

namespace FoodApplication.Controllers
{
    public class HomeController : Controller
    {
        public int userID;
        public ActionResult Index()
        {
            FoodApplicationDBEntities entities = new FoodApplicationDBEntities();
            List<Users> user = entities.Users.ToList();
            userID = user[0].UserID;
            List<Foods> foods = entities.Foods.ToList();
            List<FoodOfaDay> foodOfaDays = entities.FoodOfaDay.ToList();
           /* List<WeekMenus> weekMenus = entities.WeekMenus.ToList();

            var breakfasts = (from bf in foods
                             where bf.TypeID == 1003
                             select bf).ToList();
            
            var lunches = (from l in foods
                          where l.TypeID == 1004
                          select l).ToList();
            for (int i = 0; i < 7; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, (breakfasts.Count()));
                var breakfast = breakfasts[index];
                FoodOfaDay newFood = new FoodOfaDay();
                newFood.FoodID = breakfast.FoodID;
                DateTime today = DateTime.Now;
                TimeSpan duration = new TimeSpan(i, 0, 0, 0);
                DateTime newDate = today.Add(duration);
                newFood.Date = newDate;
                newFood.MenuID = 1000;
                entities.FoodOfaDay.Add(newFood);
                entities.SaveChanges();
                
            }
            for (int i = 0; i < 14; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, (lunches.Count()));
                var lunch = lunches[index];
                FoodOfaDay newFood = new FoodOfaDay();
                newFood.FoodID = lunch.FoodID;
                DateTime today = DateTime.Now;
                TimeSpan duration = new TimeSpan(i, 0, 0, 0);
                DateTime newDate = today.Add(duration);
                newFood.Date = newDate;
                newFood.MenuID = 1000;
                entities.FoodOfaDay.Add(newFood);
                entities.SaveChanges();

            }
            for (int i = 0; i < 7; i++)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, (breakfasts.Count()));
                var breakfast = breakfasts[index];
                FoodOfaDay newFood = new FoodOfaDay();
                newFood.FoodID = breakfast.FoodID;
                DateTime today = DateTime.Now;
                TimeSpan duration = new TimeSpan(i, 0, 0, 0);
                DateTime newDate = today.Add(duration);
                newFood.Date = newDate;
                newFood.MenuID = 1000;
                entities.FoodOfaDay.Add(newFood);
                entities.SaveChanges();

            }*/

            var weekFoods = from wf in foodOfaDays
                            where wf.MenuID == 1000
                            orderby wf.Date
                            select wf;

            return View(weekFoods);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}