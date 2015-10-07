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
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];
            allUsers.Remove(allUsers.Find( x => x.Id == currentUser.Id));
            return View(allUsers);
        }

        public ActionResult Info(int id)
        {
            UserViewModel thisUser = userService.GetById(id);
            var tweets = tweetService.GetListById(thisUser.Id);
            ViewBag.UserInfo = thisUser;

            var currentAuthorized = (UserViewModel)HttpContext.Session["CurrentUser"];
            if (currentAuthorized.Id == id)
            {
                ViewBag.currentUserPage = true;
            }
            return View(tweets);
        }

    }
}
