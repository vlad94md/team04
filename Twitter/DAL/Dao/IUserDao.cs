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
        User GetByUsername(string username);
        User Get(int id);
    }
}
