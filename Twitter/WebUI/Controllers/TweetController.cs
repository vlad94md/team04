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
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];
            var tweets = tweetService.GetListById(currentUser.Id);
            return View(tweets);
        }

        [HttpPost]
        public ActionResult AddNewTweet(TweetModel tweet)
        {
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];

            if (tweet.Body != null)
            {
                TweetModel newTweet = new TweetModel() 
                { 
                    Body = tweet.Body, 
                    Date_time = DateTime.Now, 
                    User_Id = currentUser.Id
                };

                tweetService.Add(newTweet);
                return RedirectToAction("Newsfeed", "Tweet");
            }

            var currentUserTweets = tweetService.GetListById(currentUser.Id);
            ViewBag.errorMessage = "Tweet body can't be empty!";
            return View("Newsfeed", currentUserTweets);
        }

        public ActionResult LogOut()
        {
            HttpContext.Session["CurrentUser"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
