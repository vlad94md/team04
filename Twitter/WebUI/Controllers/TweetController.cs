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
        public ActionResult Add(TweetModel tweet)
        {
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];

            if (ModelState.IsValid)
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
            return View("Newsfeed", currentUserTweets);
        }

        public ActionResult Edit(TweetViewModel tweet) 
        {
            ///// tested and it works
            tweetService.Update(tweet);
            return View();  
            
            //RedirectToAction("Info", "People", new { id = ((Models.UserViewModel)HttpContext.Session["CurrentUser"]).Id });
        }

        public ActionResult Delete(TweetViewModel tweet) 
        {
            //var b = tweetService.GetListById(1);  // for test
            //var tweet1 = b.First(x => x.Id == 1);

            ///// tested and it works
            tweetService.Delete(tweet);
            return View();  

            //RedirectToAction("Info", "People", new { id = ((Models.UserViewModel)HttpContext.Session["CurrentUser"]).Id });
        }
    }
}