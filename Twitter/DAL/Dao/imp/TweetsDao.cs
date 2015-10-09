using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data;

namespace DAL
{
    public class TweetsDao : ITweetsDao
    {
        TwitterEntities context;
        IUserDao userDao;

        public TweetsDao(IUserDao userContext)
        {
            this.userDao = userContext;
        }

        public ICollection<Tweet> GetList()
        {
            ICollection<Tweet> result;
            using (context = new TwitterEntities())
            {
                result = context.Tweets.ToList();
            }
            return result;
        }

        public bool Add(Tweet tweet)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                tweet.User = userDao.GetById(tweet.User_Id);
                context.Tweets.Attach(tweet);
                context.Tweets.Add(tweet);

                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public bool Delete(Tweet tweet)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                tweet.User = userDao.GetById(tweet.User_Id);
                context.Tweets.Attach(tweet);  // maybe not need
                context.Tweets.Remove(tweet);
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public bool Update(Tweet tweet)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                tweet.User = userDao.GetById(tweet.User_Id);
                context.Tweets.Attach(tweet);
                context.Entry(tweet).State = EntityState.Modified;
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public bool Save(int id, string text)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                var tweet = GetById(id);
                tweet.Body = text;

                context.Tweets.Attach(tweet);  // maybe not need
                context.Entry(tweet).State = EntityState.Modified;
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public Tweet GetById(int id)
        {
            //using (context = new TwitterEntities())
            //{
            //    return context.Tweets.FirstOrDefault(x => x.Id == id);
            //}

            return context.Tweets.FirstOrDefault(x => x.Id == id);
        }
    }
}
