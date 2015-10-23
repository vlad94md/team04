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
    public class UserController : Controller
    {
        private ITweetService tweetService;
        private IUserService userService;
        private IFollowService followService;

        public UserController(ITweetService _tweetService, IUserService _userService, IFollowService _followService)
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
            allUsers.Remove(allUsers.Find(x => x.Id == currentUser.Id));

            allModel.Users = allUsers;
            allModel.CurrentUserFollows = followService.GetList();       

            return View(allModel);
        }

        public ActionResult Info(int id, int page = 1)
        {
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];

            if (id == currentUser.Id)
                return RedirectToAction("UserPage");

            var infoModel = new InfoViewModel();

            infoModel.CurrentUserFollows = followService.GetList();
            infoModel.Users = userService.GetAll();
                
            UserViewModel thisUser = userService.GetById(id);
            var tweets = tweetService.GetListById(thisUser.Id);
            ViewBag.UserInfo = thisUser;

            infoModel.TweetsCount = tweets.Count;

            int pageSize = 25; 
            int totalItems = tweets.Count;
            infoModel.Tweets = tweets.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            infoModel.PageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = totalItems };

            return View(infoModel);
        }

        public ActionResult UserPage(int page = 1)
        {
            var infoModel = new InfoViewModel();
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];
            infoModel.CurrentUserFollows = followService.GetList();

            var tweets = tweetService.GetListById(currentUser.Id);
            infoModel.TweetsCount = tweets.Count;
            ViewBag.UserInfo = currentUser;

            int pageSize = 25; 
            int totalItems = tweets.Count;
            infoModel.Tweets = tweets.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            infoModel.PageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = totalItems };

            return View(infoModel);
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
