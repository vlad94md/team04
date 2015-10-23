using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class InfoViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<FollowViewModel> CurrentUserFollows { get; set; }
        public List<TweetViewModel> Tweets { get; set; }
        public int TweetsCount { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
