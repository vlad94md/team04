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

        public TweetService(ITweetsDao tweetContext)
        {
            this.tweetContext = tweetContext;
        }

        public bool AddNewTweet(TweetModel tweet)
        {
            return tweetContext.Add(TweetConverter.ConvertToDB(tweet));
        }

        
    }
}
