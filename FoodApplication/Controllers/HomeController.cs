using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodApplication.Models;
using System.Data.SqlClient;

namespace FoodApplication.Controllers
{
    public class HomeController : Controller
    {
        FoodApplicationDBEntities entities = new FoodApplicationDBEntities();
        public int userID;
        public bool noFoods;
        

        public ActionResult Index()
        {
            try
            {
                userID = (int)(Session["UserID"]);
            }
            catch (Exception)
            {

                userID = 0;
            }
            List<WeekMenus> weekMenus = entities.WeekMenus.ToList();
            List<FoodOfaDay> foodOfaDays = entities.FoodOfaDay.ToList();
            int userMenuID = new int();
            foreach (WeekMenus wm in weekMenus)
            {
                if (wm.UserID == userID)
                {
                    userMenuID = wm.MenuID;
                    break;
                }
            }
            var weekFoods = (from wf in foodOfaDays
                            where wf.MenuID == userMenuID
                            orderby wf.Date
                            select wf).ToList();
            if (weekFoods.Count > 0)
            {
                noFoods = false;
                Session["NoFoods"] = noFoods;
                return View(weekFoods);
            }
            else
            {
                noFoods = true;
                Session["NoFoods"] = noFoods;
                return View();
            }
            
        }

        public ActionResult CreateFoods()
        {
            try
            {
                userID = (int)(Session["UserID"]);
            }
            catch (Exception)
            {

                userID = 0;
            }
            List<Users> user = entities.Users.ToList();
            List<Foods> foods = entities.Foods.ToList();
            List<FoodOfaDay> foodOfaDays = entities.FoodOfaDay.ToList();
            List<WeekMenus> weekMenus = entities.WeekMenus.ToList();
            int userMenuID = new int();
            foreach (WeekMenus wm in weekMenus)
            {
                if (wm.UserID == userID)
                {
                    userMenuID = wm.MenuID;
                    break;
                }
            }

            var foodsToDelete = from wf in foodOfaDays
                            where wf.MenuID == userMenuID
                            orderby wf.Date
                            select wf;
            if (foodsToDelete.Count() == 0)
            {
                WeekMenus newWeekMenu = new WeekMenus();
                newWeekMenu.UserID = userID;
                entities.WeekMenus.Add(newWeekMenu);
                entities.SaveChanges();
                List<WeekMenus> updatedWeekMenus = entities.WeekMenus.ToList();
                foreach (WeekMenus wm in updatedWeekMenus)
                {
                    if (wm.UserID == userID)
                    {
                        userMenuID = wm.MenuID;
                        break;
                    }
                }
                
            }

            else
            {
                foreach (FoodOfaDay food in foodsToDelete)
                {
                    entities.FoodOfaDay.Remove(food);
                }
            }

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
                 newFood.MenuID = userMenuID;
                 entities.FoodOfaDay.Add(newFood);
                 entities.SaveChanges();

             }
             for (int i = 0; i < 7; i++)
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
                 newFood.MenuID = userMenuID;
                 entities.FoodOfaDay.Add(newFood);
                 entities.SaveChanges();

             }
            for (int i = 0; i < 7; i++)
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
                newFood.MenuID = userMenuID;
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
                 DateTime today = DateTime.Now.Date;
                 TimeSpan duration = new TimeSpan(i, 0, 0, 0);
                 DateTime newDate = today.Add(duration);
                 newFood.Date = newDate;
                 newFood.MenuID = userMenuID;
                 entities.FoodOfaDay.Add(newFood);
                 entities.SaveChanges();

            }

            var weekFoods = from wf in foodOfaDays
                            where wf.MenuID == userMenuID
                            orderby wf.Date
                            select wf;

            return RedirectToAction("Index");
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