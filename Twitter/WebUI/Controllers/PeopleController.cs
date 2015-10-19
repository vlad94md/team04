using Models;
using Models.ViewModels;
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
        private IFollowService followService;

        public PeopleController(ITweetService _tweetService, IUserService _userService,IFollowService _followService)
        {
            this.tweetService = _tweetService;
            this.userService = _userService;
            this.followService = _followService;
        }

        public ActionResult All()
        {            
            AllViewModel allModel = new AllViewModel();

            var allUsers = userService.GetAll();
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];
            allUsers.Remove(allUsers.Find( x => x.Id == currentUser.Id));

            allModel.Users = allUsers;
            allModel.CurrentUserFollows = followService.GetList();          //followService.GetFollows(currentUser.Id);

            return View(allModel);
        }

        public ActionResult Info(int id)
        {
            UserViewModel thisUser = userService.GetById(id);
            var tweets = tweetService.GetListById(thisUser.Id);
            ViewBag.UserInfo = thisUser;

            return View(tweets);
        }

        public ActionResult UserPage(int id)
        {
            UserViewModel thisUser = userService.GetById(id);
            var tweets = tweetService.GetListById(thisUser.Id);
            ViewBag.UserInfo = thisUser;

            return View(tweets);
        }

        public ActionResult Follow(int publisherId, int subsriberId)
        {
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];
            subsriberId = currentUser.Id;
            followService.Follow(publisherId, subsriberId);
       
            return View();
        }

        public ActionResult Unfollow(int id)
        {
            followService.UnFollow(id);
            return View();
        }
    }
}
