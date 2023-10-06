using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Users u)
        {
            Users loggedUser = Db.GetUserByUsername(u.Username);
            if (loggedUser != null && loggedUser.Psw == u.Psw)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        
    }
}