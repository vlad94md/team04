using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class CRUD
    {
        TwitterEntities twitterDB;

        public CRUD()
        {
            twitterDB = new TwitterEntities();
        }

        public bool AddNewUser(User user)
        {
            twitterDB.Users.Add(user);
            twitterDB.SaveChanges();
            return true;
        }
    }
}
