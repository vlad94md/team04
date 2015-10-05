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

        public ActionResult Newsfeed()
        {
            // get list of tweetviewmodel of current user and put into View
            return View();
        }

        [HttpPost]
        public ActionResult Newsfeed(TweetModel tweet)
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

                tweetService.AddNewTweet(newTweet);
                return RedirectToAction("Index", "Home");

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
