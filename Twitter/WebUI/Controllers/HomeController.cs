using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System;
using Services;
namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;
        //private bool loggedIn = false;

        public HomeController(IUserService _userService)
        {
            userService = _userService;
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