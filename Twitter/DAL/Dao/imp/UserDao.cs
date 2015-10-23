using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data;
using StaticLogger;

namespace DAL
{
    public class UserDao : IUserDao
    {
        public ICollection<User> GetList()
        {
            ICollection<User> result;
            using (var context = new TwitterEntities())
            {
                result = context.Users.ToList(); 
            }
            return result;
        }

        public bool Add(User user)
        {
            if (user == null) return false;

            bool result = false;
            using (var context = new TwitterEntities())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Added;
                result = context.SaveChanges() > 0;
                Logger.Log.Debug("new user ID:" + user.Id + " " + user.Email + " was added successfully");
            }
            return result;
        }

        public bool Delete(User user)
        {
            bool result = false;
            using (var context = new TwitterEntities())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Deleted;
                result = context.SaveChanges() > 0;
                Logger.Log.Debug("new user ID:" + user.Id + " " + user.Email + " was deleted successfully");
            }
            return result;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            bool result = false;
            using (var context = new TwitterEntities())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                result = context.SaveChanges() > 0;
            }
            return result;
        }

        public User GetById(int id)
        {
            User result = null;
            using (var context = new TwitterEntities())
            {
                result = context.Users.FirstOrDefault(x => x.Id == id);
            }
            return result;
        }
    }
}
