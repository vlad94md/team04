using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITweetService
    {
        bool Add(TweetModel tweet);
        List<TweetViewModel> GetListById(int userId);
    }
}
