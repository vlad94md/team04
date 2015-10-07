using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Services;

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
                    return RedirectToAction("Newsfeed", "Tweet");
                }
                else
                {
                    ViewBag.errorMessage = "Username or Password is incorrect!";
                    return View();
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            HttpContext.Session["CurrentUser"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}