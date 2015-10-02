using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System;
using Services;
namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ITweetService tweetS;

        public HomeController(ITweetService _tweetS)
        {
            this.tweetS = _tweetS;
        }

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Newsfeed()
        {
            if (true)
            {
                return View();
            }
            //else
            //{
            //    return RedirectToAction("Index", "Home", new { Msg = "Not logged In" });
            //}
        }

        [HttpPost]
        public ActionResult Newsfeed(TweetModel tweet)
        {
            if (ModelState.IsValid)
            {
                TweetModel test = new TweetModel() { Body = "test", Date_time = DateTime.Now, User_Id = 1};
                tweetS.AddNewTweet(test);
                return RedirectToAction("Home", "Index");

            }
            return View();
        }
    }
}