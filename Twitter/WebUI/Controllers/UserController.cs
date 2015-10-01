using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Services;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel newUser)
        {
            if (ModelState.IsValid)
            {
                userService.AddNewUser(newUser);
                return RedirectToAction("LogIn", "User", new { Msg = "Register successfully" });
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInUserModel currentUser)
        {
            if (ModelState.IsValid)
            {
                //if (userService.IsLoginPassCorrect(currentUser))
                //{
                //    return RedirectToAction("Newsfeed", "Home", new { Msg = "Logged In" });
                //}
                //else
                //{
                //    return View();
                //}

                return View(); // delete after decomment
            }
            else
            {
                return View();
            }
        }
    }
}