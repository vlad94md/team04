using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class BaseDal
    {
        TwitterEntities twitterDB;

        public BaseDal()
        {
            //twitterDB = new TwitterEntities();
        }

        public bool AddNewUser(User user)
        {
            bool result = false;
            using (twitterDB = new TwitterEntities())
            {
                twitterDB.Users.Add(user);
                twitterDB.SaveChanges();
                result = true;
            }
            return result;
        }
        
        public bool IsLoginPassCorrect(User user)
        {
            bool result = false;
            using (twitterDB = new TwitterEntities())
            {
                result = twitterDB.Users.Any(x => x.Username == user.Username && x.Passwrd == user.Passwrd);
            }
            return result;
        }
    }
}
