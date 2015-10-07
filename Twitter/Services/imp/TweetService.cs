using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Converter;

namespace Services
{
    public class TweetService : ITweetService
    {
        private ITweetsDao tweetContext;
        private IUserDao userContext;

        public TweetService(ITweetsDao tweetContext, IUserDao userContext)
        {
            this.tweetContext = tweetContext;
            this.userContext = userContext;
        }

        public bool Add(TweetModel tweet)
        {
            return tweetContext.Add(TweetConverter.ConvertToDB(tweet));
        }

        public List<TweetViewModel> GetListById(int userId)
        {
            List<TweetViewModel> result = new List<TweetViewModel>();
            var allTweets = tweetContext.GetList();
            var currUser = userContext.GetById(userId);

            foreach (var item in allTweets)
            {
                if (item.User_Id == currUser.Id)
                {
                    result.Add(TweetConverter.ConvertToViewModel(item));
                }
            }
            result = result.OrderByDescending(x => x.DateAdded).ToList();
            return result;
        }

    }
}
