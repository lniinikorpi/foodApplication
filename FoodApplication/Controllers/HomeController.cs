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
        public ActionResult Index()
        {
            FoodApplicationDBEntities entities = new FoodApplicationDBEntities();
            List<Foods> model = entities.Foods.ToList();
            entities.Dispose();
            return View(model);
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