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
        public bool creationSuccesful;

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
            return RedirectToAction("Index");
        }

        public ActionResult LoginSuccesful()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
        public ActionResult AccountCreated(string userName, string password)
        {
            try
            {
                List<Users> users = entities.Users.ToList();
                Users newUser = new Users();
                newUser.UserName = userName;
                newUser.Password = password;
                entities.Users.Add(newUser);
                entities.SaveChanges();
                creationSuccesful = true;
                Session["CreationSuccesful"] = creationSuccesful;
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                creationSuccesful = false;
                Session["CreationSuccesful"] = creationSuccesful;
                return RedirectToAction("CreateAccount");
            }
        }
    }
}