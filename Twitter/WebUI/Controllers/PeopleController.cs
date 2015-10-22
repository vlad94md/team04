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

        public PeopleController(ITweetService _tweetService, IUserService _userService, IFollowService _followService)
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
            var badgeModel = new BadgeModel();
            var allUsers = userService.GetAll();
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];

            if (id == currentUser.Id)
                return RedirectToAction("UserPage");

            //1.
            badgeModel.CurrentUserFollows = followService.GetList();
            //2.
            badgeModel.Users = allUsers;
                
            UserViewModel thisUser = userService.GetById(id);
            var tweets = tweetService.GetListById(thisUser.Id);
            ViewBag.UserInfo = thisUser;
            //3.
            badgeModel.TweetsCount = tweets.Count;

            int pageSize = 10; // количество объектов на страницу
            int totalItems = tweets.Count;
            badgeModel.Tweets = tweets.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = totalItems };
            badgeModel.PageInfo = pageInfo;

            return View(badgeModel);
        }

        public ActionResult UserPage(int page = 1)
        {
            var badgeModel = new BadgeModel();
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];
            UserViewModel thisUser = userService.GetById(currentUser.Id);
            badgeModel.CurrentUserFollows = followService.GetList();
            
            var tweets = tweetService.GetListById(thisUser.Id);
            badgeModel.TweetsCount = tweets.Count;
            ViewBag.UserInfo = thisUser;

            int pageSize = 10;  ///REPEATEABLE CODE
            int totalItems = tweets.Count;
            badgeModel.Tweets = tweets.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = totalItems };
            badgeModel.PageInfo = pageInfo;

            return View(badgeModel);
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
