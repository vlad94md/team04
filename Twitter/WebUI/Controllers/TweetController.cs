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
        public ActionResult Newsfeed(int page = 1)
        {
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];

            var followingUsers = followService.GetFollows(currentUser.Id);

            List<TweetViewModel> allFollowingUsersTweets = new List<TweetViewModel>();

            allFollowingUsersTweets.AddRange(tweetService.GetListById(currentUser.Id)); 

            foreach (var user in followingUsers)
	        {
                allFollowingUsersTweets.AddRange(tweetService.GetListById(user.Id));
	        }

            allFollowingUsersTweets = allFollowingUsersTweets.OrderByDescending(x => x.DateAdded).ToList();

            var neewsfeedModel = CreateNeewsfeedModel(25, allFollowingUsersTweets.Count, page, allFollowingUsersTweets);

            return View(neewsfeedModel);
        }

        private NewsfeedViewModel CreateNeewsfeedModel(int pageSize, int totalItems, int curPage, List<TweetViewModel> tweets)
        {
            var tweetsForCurrentPage = tweets.Skip((curPage - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = curPage, PageSize = pageSize, TotalItems = totalItems };
            return new NewsfeedViewModel { PageInfo = pageInfo, Tweets = tweetsForCurrentPage, TweetsCount = totalItems };
        }

        [HttpPost]
        public ActionResult Add(TweetModel tweet)
        {
            var currentUser = (UserViewModel)HttpContext.Session["CurrentUser"];
            var currentUserTweets = tweetService.GetListById(currentUser.Id);

            if (ModelState.IsValid)
            {
                TweetModel newTweet = new TweetModel()
                {
                    Body = tweet.Body,
                    Date_time = DateTime.Now,
                    User_Id = currentUser.Id
                };

                tweetService.Add(newTweet);
                currentUserTweets = tweetService.GetListById(currentUser.Id);

                return PartialView("TweetPartial", currentUserTweets);
            }
            ViewBag.errorMessage = "Tweet body can't be empty and maximum 140 characters!";
            return PartialView("TweetPartial", currentUserTweets);
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