using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TweetModel
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Body { get; set; }
        public System.DateTime Date_time { get; set; }

        public virtual UserModel User { get; set; }

    }
}
