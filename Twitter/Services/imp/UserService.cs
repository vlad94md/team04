using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Converter;
using DAL.Entities;

namespace Services
{
    public class UserService : IUserService
    {
        private IUserDao userContext;

        public UserService(IUserDao userContext)
        {
            this.userContext = userContext;
        }

        public bool AddNewUser(UserModel user)
        {
            return userContext.Add(UserConverter.ConvertToDB(user));
        }

        public bool IsUsernameUnique(string username)
        {
            var allUsers = userContext.GetList();

            return !allUsers.Any(x => x.Username == username);
        }

        public bool IsEmailUnique(string email)
        {
            var allUsers = userContext.GetList();

            return !allUsers.Any(x => x.Email == email);
        }

        public UserViewModel IsUsernamePassCorrect(LogInUserViewModel model)
        {
            var curUser = userContext.GetList().FirstOrDefault(x => x.Username == model.Username);
            if (curUser != null)
            {
                if (curUser.Passwrd == model.Passwrd)
                    return UserConverter.ConvertToViewModel(curUser);
            }
            return null;
        }

        public UserViewModel GetById(int id)
        {
            User currUser = userContext.GetById(id);
            return UserConverter.ConvertToViewModel(currUser);
        }

        public List<UserViewModel> GetAll()
        {
            List<UserViewModel> result = new List<UserViewModel>();
            var allUsers = userContext.GetList();
            foreach (var user in allUsers)
            {
                result.Add(UserConverter.ConvertToViewModel(user));
            }
            return result;
        }
    }
}
