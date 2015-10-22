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
            var thisUserTweets = tweetContext.GetList().Where( x => x.User_Id == userId);

            foreach (var tweet in thisUserTweets)
            {
                var convertedTweet = TweetConverter.ConvertToViewModel(tweet);
                convertedTweet.Author = userContext.GetById(convertedTweet.AuthorId).FullName;
                result.Add(convertedTweet);
            }

            result = result.OrderByDescending(x => x.DateAdded).ToList();
            return result;
        }

        public bool Update(TweetViewModel tweet)
        {
            return tweetContext.Update(TweetConverter.ConvertToDB(tweet));
        }

        public bool Update(int id, string text)
        {
            return tweetContext.Save(id, text);
        }

        public bool Delete(int id)
        {
            return tweetContext.Delete(id);
        }
    }
}
