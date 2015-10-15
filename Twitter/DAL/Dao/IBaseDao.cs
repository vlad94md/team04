using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBaseDao<T>
    {
        ICollection<T> GetList();
        bool Add(T t);
        bool Delete(int id);
        bool Delete(T t);
        bool Update(T t);
        T GetById(int id);
    }
}
