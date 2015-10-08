using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data;

namespace DAL
{
    public class UserDao : IUserDao
    {
        TwitterEntities context;

        public UserDao()
        {
            //twitterDB = new TwitterEntities();
        }

        public ICollection<User> GetList()
        {
            ICollection<User> result;
            using (context = new TwitterEntities())
            {
                result = context.Users.ToList(); 
            }
            return result;
        }

        public bool Add(User user)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                context.Users.Add(user);
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public bool Delete(User user)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                context.Users.Remove(user);
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public bool Update(User user)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public User GetByUsername(string username)
        {
            User result = null;
            using (context = new TwitterEntities())
            {
                result = context.Users.FirstOrDefault(x => x.Username == username);
            }
            return result;
        }

        public User GetById(int id)
        {
            User result = null;
            using (context = new TwitterEntities())
            {
                result = context.Users.FirstOrDefault(x => x.Id == id);
            }
            return result;
        }
    }
}
