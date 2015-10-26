using Models;
using Models.ViewModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace WebUI.Controllers
{
    public class TweetController : Controller
    {
        private ITweetService tweetService;
        private IUserService userService;
        private IFollowService followService;

        public TweetController(ITweetService _tweetService, IUserService _userService, IFollowService _followService)
        {
            this.tweetService = _tweetService;
            this.userService = _userService;
            this.followService = _followService;
        }

        [HttpGet]
        public ActionResult Newsfeed(int? page = 1)
        {
            int pageSize = 25;
            int pageNumber = (page ?? 1);

            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];

            var followingUsers = followService.GetFollows(currentUser.Id);

            List<TweetViewModel> allFollowingUsersTweets = new List<TweetViewModel>();

            allFollowingUsersTweets.AddRange(tweetService.GetListById(currentUser.Id));

            foreach (var user in followingUsers)
            {
                allFollowingUsersTweets.AddRange(tweetService.GetListById(user.Id));
            }

            allFollowingUsersTweets = allFollowingUsersTweets.OrderByDescending(x => x.DateAdded).ToList();

            return View("Newsfeed", allFollowingUsersTweets.ToPagedList(pageNumber, pageSize));
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
            }
            else
            {
                ViewBag.errorMessage = "Tweet body can't be empty and maximum 140 characters!";
            }
            
            var currentUserTweets = tweetService.GetListById(currentUser.Id).ToPagedList(1, 25);
            return View("TweetPartial", currentUserTweets);
        }

        public ActionResult Edit(int id, string text)
        {
            tweetService.Update(id, text);
            return View();
        }

        public ActionResult Delete(int id)
        {
            tweetService.Delete(id);
            return View();
        }
    }
}