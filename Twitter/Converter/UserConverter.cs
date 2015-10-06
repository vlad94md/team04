using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.Entities;

namespace Converter
{
    public static class UserConverter
    {
        public static User ConvertToDB(UserModel user)
        {
            var newUser = new User { 
                FullName = user.FullName, 
                Username = user.Username, 
                Email = user.Email, 
                Passwrd = user.Passwrd 
            };

            return newUser;
        }

        public static User ConvertToDB(LogInUserViewModel user)
        {
            var currentUser = new User
            {
                Username = user.Username,
                Passwrd = user.Passwrd
            };

            return currentUser;
        }

        public static UserViewModel ConvertToViewModel(User user)
        {
            var userViewModel = new UserViewModel
            {
                 Id = user.Id,
                 FullName = user.FullName,
                 Username = user.Username,
                 Email = user.Email
            };

            return userViewModel;
        }
    }
}
