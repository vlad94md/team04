using BL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private UserManager userManager;
        //private bool loggedIn = false;

        public HomeController()
        {
            userManager = new UserManager();

            //var temp = new LogInUserModel();
            //try
            //{
            //    temp.Username = Request.Cookies["LoggedUsername"].Value;
            //    temp.Passwrd = Request.Cookies["LoggedPassword"].Value;
            //}
            //catch (NullReferenceException)
            //{
            //    temp.Username = "";
            //    temp.Passwrd = "";
            //}

            //if (userManager.IsLoginPassCorrect(temp))
            //{
            //    loggedIn = true;
            //}
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Newsfeed()
        {
            if (true)
                return View();
            else
                return RedirectToAction("Index", "Home", new { Msg = "Not logged In" });
        }
    }
}