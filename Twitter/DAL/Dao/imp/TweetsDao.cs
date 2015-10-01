using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class TweetsDao : ITweetsDao
    {
        TwitterEntities context;
    }
}
