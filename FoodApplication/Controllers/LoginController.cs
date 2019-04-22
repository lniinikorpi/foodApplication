using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodApplication.Models;

namespace FoodApplication.Controllers
{
    public class LoginController : Controller
    {
        FoodApplicationDBEntities entities = new FoodApplicationDBEntities();
        public int userID;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            List<Users> users = entities.Users.ToList();
            foreach (Users u in users)
            {
                if (userName == u.UserName && password == u.Password)
                {
                    //userID = u.UserID;
                    int userID = u.UserID;
                    Session["UserID"] = userID;
                    return RedirectToAction("LoginSuccesful");
                    //break;
                }
            }
            return View();
        }

        public ActionResult LoginSuccesful()
        {
            return View();
        }
    }
}