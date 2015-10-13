using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Services;
using WebUI.App_Start;
using StaticLogger;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel newUser)
        {
            if (ModelState.IsValid)
            {
                if (GetErrors(newUser) == null)
                {
                    userService.AddNewUser(newUser);
                    Logger.Log.Debug("new user " + newUser.Username + " " + newUser.Email + " has registered");
                    return RedirectToAction("RegisterSuccess", "User");
                }
                ViewBag.errorMessage = GetErrors(newUser);
            }
            return View();
        }

        private string GetErrors(UserModel newUser)
        {
            if (!userService.IsUsernameUnique(newUser.Username))
                return "Username is already in use!";
            if (!userService.IsEmailUnique(newUser.Email))
                return "Email is already in use!";
            return null;
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInUserViewModel currentUser)
        {
            if (ModelState.IsValid)
            {
                var acceptedUser = userService.IsUsernamePassCorrect(currentUser);
                if (acceptedUser != null)
                {
                    HttpContext.Session["CurrentUser"] = acceptedUser;
                    Logger.Log.Debug("user ID:" + acceptedUser.Id + " username:" + acceptedUser.Username + " logged in");
                    return RedirectToAction("Newsfeed", "Tweet");
                }
                else
                {
                    ViewBag.errorMessage = "Email or Password is incorrect!";
                    return View();
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            var leftUser = (UserViewModel)HttpContext.Session["CurrentUser"];
            Logger.Log.Debug("user ID:" + leftUser.Id + " username:" + leftUser.Username + " logged out");
            HttpContext.Session["CurrentUser"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}