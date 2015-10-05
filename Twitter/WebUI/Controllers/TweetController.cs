using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class TweetController : Controller
    {
        private ITweetService tweetService;
        private IUserService userService;

        public TweetController(ITweetService _tweetService, IUserService _userService)
        {
            this.tweetService = _tweetService;
            this.userService = _userService;
        }

        [HttpGet]
        public ActionResult Newsfeed()
        {
            LogInUserViewModel currentUser = (LogInUserViewModel)HttpContext.Session["CurrentUser"];
            var tweets = tweetService.GetListByUsername(currentUser.Username);
            return View(tweets);
        }

        [HttpPost]
        public ActionResult AddNewTweet(TweetModel tweet)
        {
            if (ModelState.IsValid)
            {
                LogInUserViewModel currentUser = (LogInUserViewModel)HttpContext.Session["CurrentUser"];
                TweetModel newTweet = new TweetModel() 
                { 
                    Body = tweet.Body, 
                    Date_time = DateTime.Now, 
                    User_Id = userService.GetIdByUsername(currentUser.Username)
                };

                tweetService.Add(newTweet);
                return RedirectToAction("Newsfeed", "Tweet");

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
