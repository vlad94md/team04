using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TweetViewModel
    {
        public int User_Id { get; set; } 
        public string Body { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
