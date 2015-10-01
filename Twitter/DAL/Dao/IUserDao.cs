using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public interface IUserDao : IBaseDao<User>
    {
        //bool Add(User user);
        bool IsUsernameExists(string username);
        bool IsEmailExists(string email);
        User GetByUsername(string username);
    }
}
