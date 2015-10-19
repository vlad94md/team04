using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class FollowsDao : IFollowsDao
    {
        private TwitterEntities context;
        private IUserDao user;

        public FollowsDao(IUserDao _user)
        {
            this.user = _user;
        }

        public bool Add(int id, int id2)
        {
            bool result = false;

            var follow = new Follow
            {
                Publisher_Id = id,
                Subscriber_Id = id2,
                User = user.GetById(id),
                User1 = user.GetById(id2)
            };

            using (var context = new TwitterEntities())
            {
                context.Follows.Attach(follow);
                context.Follows.Add(follow);

                result = context.SaveChanges() > 0;
            }

            return result;
        }

        public ICollection<User> GetUserFollows(int currentUserId)
        {
            List<User> result = new List<User>();            
            using (var context = new TwitterEntities())
            {
                var xd = context.Follows.Where(x => x.Subscriber_Id == currentUserId && x.Publisher_Id != null);

                foreach (var item in xd)
                {
                    result.Add(user.GetById(item.Publisher_Id));
                }
            }
            return result.ToList();
        }

        public ICollection<Follow> GetList()
        {
            ICollection<Follow> result;
            using (var context = new TwitterEntities())
            {
                result = context.Follows.ToList();
            }
            return result;
        }

        public Follow GetById(int id)
        {
            var context = new TwitterEntities();
            return context.Follows.FirstOrDefault(x => x.Publisher_Id == id);
        }

        public bool Delete(int id)
        {
            bool result = false;
            using (var context = new TwitterEntities())
            {
                var follow = GetById(id);
                //follow.User = user.GetById(id);
                //follow.User1 = user.GetById(follow.Subscriber_Id);
                context.Follows.Attach(follow);
                context.Follows.Remove(follow);
                result = context.SaveChanges() > 0;
            }
            return result;
        }
    }
}