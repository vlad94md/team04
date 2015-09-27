using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Converter;

namespace BL
{
    public class UserManager
    {
        CRUD crud;
        UserConverter userConverter;

        public UserManager()
        {
            crud = new CRUD();
            userConverter = new UserConverter();
        }

        public void AddNewUser(UserModel user)
        {
            crud.AddNewUser( userConverter.ConvertToDB(user) );
        }

        public bool IsLoginPassCorrect(LogInUserModel currentUser)
        {
            return crud.IsLoginPassCorrect( userConverter.ConvertToDB(currentUser) );
        }
    }
}
