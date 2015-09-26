using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.Entities;

namespace Converter
{
    public class UserConverter
    {
        public User ConvertToDB(UserModel user)
        {
            var newUser = new User { 
                FullName = user.FullName, 
                Username = user.Username, 
                Email = user.Email, 
                Passwrd = user.Passwrd 
            };

            return newUser;
        }
    }
}
