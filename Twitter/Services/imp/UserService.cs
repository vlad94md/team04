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
        private IFollowService followContext;

        public UserService(IUserDao userContext, IFollowService followContext)
        {
            this.userContext = userContext;
            this.followContext = followContext;
        }

        public bool AddNewUser(UserModel user)
        {
            return userContext.Add(UserConverter.ConvertToDB(user));
        }

        public bool IsEmailUnique(string email)
        {
            var allUsers = userContext.GetList();

            return !allUsers.Any(x => x.Email == email);
        }

        public UserViewModel IsEmailAndPassCorrect(LogInUserViewModel model)
        {
            var curUser = userContext.GetList().FirstOrDefault(x => x.Email == model.Email);
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

        public List<UserViewModel> GetAll(int currentUserId)
        {
            List<UserViewModel> result = new List<UserViewModel>();
            var allUsers = userContext.GetList();
            foreach (var user in allUsers)
            {
                UserViewModel convertedUser = UserConverter.ConvertToViewModel(user);
                convertedUser.IsFollowedByCurrent = (followContext.GetList().Where(h => h.SubId == currentUserId && h.PubId == user.Id).ToList().Count > 0); //change
                result.Add(convertedUser); 
            }
            return result;
        }

        public void EditUser(UserViewModel user)
        {
            userContext.Update(UserConverter.ConvertViewModelToDB(user));
        }
    }
}
