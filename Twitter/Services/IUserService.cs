using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        bool AddNewUser(UserModel user);
        bool IsUsernameUnique(string username);
        bool IsEmailUnique(string email);
        bool IsUsernamePassCorrect(LogInUserModel currentUser);
    }
}
