using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Converter;

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

        //public bool IsLoginPassCorrect(LogInUserModel currentUser)
        //{
        //    //return crud.IsLoginPassCorrect( UserConverter.ConvertToDB(currentUser) );
        //    throw new NotImplementedException();
        //}
    }
}
