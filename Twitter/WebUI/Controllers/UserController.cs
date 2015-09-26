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
                return View("Register");
            }
            else
            {
                return View();
            }
        }

    }
}
