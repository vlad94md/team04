using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

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

        public bool Delete(User book)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                context.Users.Remove(book);
                result = context.SaveChanges() > 0;
            }
            return result;
        }


        public bool IsUsernameExists(string username)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                result = context.Users.Any(x => x.Username == username);
            }
            return result;
        }

        public bool IsEmailExists(string email)
        {
            bool result = false;
            using (context = new TwitterEntities())
            {
                result = context.Users.Any(x => x.Email == email);
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
    }
}
