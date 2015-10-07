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
        //[Required(ErrorMessage = "Tweet message can't be empty!")]
        public string Body { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
