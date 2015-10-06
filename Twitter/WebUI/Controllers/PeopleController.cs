using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class PeopleController : Controller
    {
        private ITweetService tweetService;
        private IUserService userService;

        public PeopleController(ITweetService _tweetService, IUserService _userService)
        {
            this.tweetService = _tweetService;
            this.userService = _userService;
        }

        public ActionResult All()
        {
            var allUsers = userService.GetAll();
            return View(allUsers);
        }

        public ActionResult Info(int id)
        {
            UserViewModel currentUser = userService.GetById(id);
            var tweets = tweetService.GetListByUsername(currentUser.Username);
            ViewBag.UserInfo = currentUser;
            return View(tweets);
        }

    }
}
