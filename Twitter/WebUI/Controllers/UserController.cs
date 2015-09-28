using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BL;

namespace WebUI.Controllers
{

        public class UserController : Controller
        {
            UserManager userManager;

            public UserController()
            {
                userManager = new UserManager();
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
                    userManager.AddNewUser(newUser);
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
                    if (userManager.IsLoginPassCorrect(currentUser))
                    {
                        //var cookieLogin = new HttpCookie("LoggedUsername")
                        //{
                        //    Name = "LoggedUsername",
                        //    Value = currentUser.Username,
                        //    Expires = DateTime.Now.AddMinutes(5),
                        //};

                        //var cookiePass = new HttpCookie("LoggedPassword")
                        //{
                        //    Name = "LoggedPassword",
                        //    Value = currentUser.Passwrd,
                        //    Expires = DateTime.Now.AddMinutes(5),
                        //};
                        //Response.SetCookie(cookieLogin);
                        //Response.SetCookie(cookiePass);

                        return RedirectToAction("Newsfeed", "Home", new { Msg = "Logged In" });
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }

        }
}
